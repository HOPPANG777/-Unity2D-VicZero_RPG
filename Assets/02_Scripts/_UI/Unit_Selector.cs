using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;


public class Unit_Selector : MonoBehaviour
{
    [Header("Arrow_Prefabs")]
    public GameObject Arrow_Indicator_Prefab; // 화살표 프리팹 

    [Header("Arrow_GameObject & Unit_GameObject")]
    public GameObject Current_Arrow;
    public Unit_Player Current_Unit;
    public Unit_Enemy Current_Enemy;
    public List<Unit_Enemy> Selected_Enemies = new List<Unit_Enemy>(); // 선택된 적 유닛 목록 
    
    private void Start()
    {
        if (All_Manager.instance.Setting_M.Game_Stop == false)
        {
            if (All_Manager.instance.Setting_M.Stage_In == true)
            {
                // 초기 상태에서는 화살표와 컨트롤 패널 비활성화 
                All_Manager.instance.UI_M.Choice_Controll_Panel.gameObject.SetActive(false);
                Current_Arrow = Instantiate(Arrow_Indicator_Prefab);
                Current_Arrow.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (All_Manager.instance.Setting_M.Game_Stop == false)
        {
            if (All_Manager.instance.Setting_M.Stage_In == true)
            {
                if (All_Manager.instance.GameMode_M.Turn_State == GameMode_Manager.Battle_State.PLAYER_TURN) Update_Unit_Selector();
            }
        }
    }

    public void Update_Unit_Selector()
    {
        // 플레이어 선택 
        if (Input.GetMouseButtonDown(0)) // 마우스 클릭 
        {
            Vector3 Mouse_Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D Hit_Collider = Physics2D.OverlapPoint(Mouse_Pos);

            if (Hit_Collider != null)
            {
                Unit_Player Selected_Unit = Hit_Collider.GetComponent<Unit_Player>();

                if (Selected_Unit != null) // 유닛이 클릭되었을 때 
                {
                    Select_Player_Unit(Selected_Unit);
                }
                else if (Current_Unit != null) // 플레이어 유닛이 선택된 후 적 유닛 선택 
                {
                    Unit_Enemy Selected_Enemy = Hit_Collider.GetComponent<Unit_Enemy>();
                    if (Selected_Enemy != null)
                    {
                        //Select_Enemy_Unit(Selected_Enemy);
                        Select_Enemy_Unit_Single(Selected_Enemy);

                        All_Manager.instance.UI_M.Choice_Controll.Set_Button();
                    }
                }
            }
        }
    }

    public void Select_Player_Unit(Unit_Player Unit)
    {
        // 이전에 선택된 유닛의 화살표 숨기기 
        if (Current_Unit != null)
        {
            Current_Arrow.SetActive(false);
            for (int i = 0; i < All_Manager.instance.UI_M.Character_Name_Text.Count; i++)
            {
                All_Manager.instance.UI_M.Character_Name_Text[i].color = Color.white;
            }
        }

        // 새로운 유닛 선택 
        Current_Unit = Unit;

        var Player_Name = All_Manager.instance.UI_M.Character_Name_Text;
        TextMeshProUGUI Current_Player_Name = null;

        for (int i = 0; i < Player_Name.Count; i++)
        {
            if (Player_Name[i].text.Contains(Unit.Unit_Name))
            {
                Current_Player_Name = Player_Name[i];
            }
        }

        Current_Player_Name.color = Color.yellow;

        // 화살표를 현재 선택된 유닛 머리 위로 이동하고 노란색으로 설정한 후 활성화 
        Current_Arrow.transform.position = Current_Unit.transform.position + new Vector3(0, -0.3f, 0);
        Current_Arrow.GetComponent<SpriteRenderer>().color = Color.yellow;
        Current_Arrow.SetActive(true);

        // 컨트롤 패널 비활성화 (적 선택 전까지) 
        All_Manager.instance.UI_M.Choice_Controll_Panel.gameObject.SetActive(false);
    }

    public void Select_Enemy_Unit(Unit_Enemy Unit)
    {
        // 이미 선택된 적 유닛인지 확인 
        if (Selected_Enemies.Contains(Unit))
        {
            // 이미 선택된 경우 선택 해제 
            Selected_Enemies.Remove(Unit);
            Current_Unit.unitTarget = null;
            //Color unitColor = Unit.gameObject.GetComponent<SpriteRenderer>().color;
            //unitColor.a = 1.0f; // 선택 해제 시 알파값을 원래대로 변경 
            //Unit.gameObject.GetComponent<SpriteRenderer>().color = unitColor;
        }
        else
        {
            // 새로운 적 유닛 선택 
            Selected_Enemies.Add(Unit);
            Current_Unit.unitTarget = Unit;
            //Color unitColor = Unit.gameObject.GetComponent<SpriteRenderer>().color;
            //unitColor.a = 0.5f; // 선택된 유닛은 알파값을 낮춰서 표시 
            //Unit.gameObject.GetComponent<SpriteRenderer>().color = unitColor;
        }

        // 화살표를 적 유닛 머리 위로 이동하고 빨간색으로 설정한 후 활성화 
        Current_Arrow.transform.position = Unit.transform.position + new Vector3(0, 1.0f, 0);
        Current_Arrow.GetComponent<SpriteRenderer>().color = Color.red;
        Current_Arrow.SetActive(true);

        // 컨트롤 패널 활성화 (적 유닛이 하나 이상 선택된 경우) 
        if (Selected_Enemies.Count > 0)
        {
            All_Manager.instance.UI_M.Choice_Controll_Panel.gameObject.SetActive(true);
        }
        else
        {
            All_Manager.instance.UI_M.Choice_Controll_Panel.gameObject.SetActive(false);
        }
    }

    public void Select_Enemy_Unit_Single(Unit_Enemy Unit)
    {
        if (Current_Enemy == null)
        {
            Current_Arrow.SetActive(false);
            for (int i = 0; i < All_Manager.instance.UI_M.Enemy_Name_Text.Count; i++)
            {
                All_Manager.instance.UI_M.Enemy_Name_Text[i].color = Color.white;
            }
        }

        Current_Enemy = Unit;

        Current_Unit.unitTarget = Unit;

        var Enemy_Name = All_Manager.instance.UI_M.Enemy_Name_Text;
        TextMeshProUGUI Current_Enemy_Name = null;

        for (int i = 0; i < Enemy_Name.Count; i++)
        {
            if (Enemy_Name[i].text.Contains(Unit.Unit_Name))
            {
                Current_Enemy_Name = Enemy_Name[i];
            }
        }

        Current_Enemy_Name.color = Color.blue;

        // 화살표를 적 유닛 머리 위로 이동하고 빨간색으로 설정한 후 활성화 
        Current_Arrow.transform.position = Unit.transform.position + new Vector3(0, 1.0f, 0);
        Current_Arrow.GetComponent<SpriteRenderer>().color = Color.red;
        Current_Arrow.SetActive(true);

        // 컨트롤 패널 활성화
        if (Current_Enemy != null)
        {
            All_Manager.instance.UI_M.Choice_Controll_Panel.gameObject.SetActive(true);
        }
        else
        {
            All_Manager.instance.UI_M.Choice_Controll_Panel.gameObject.SetActive(false);
        }
    }


    public void Reset_Arrow()
    {
        Current_Arrow.SetActive(false);

        for (int i = 0; i < All_Manager.instance.UI_M.Enemy_Name_Text.Count; i++)
        {
            All_Manager.instance.UI_M.Enemy_Name_Text[i].color = Color.white;
        }

        for (int i = 0; i < All_Manager.instance.UI_M.Character_Name_Text.Count; i++)
        {
            All_Manager.instance.UI_M.Character_Name_Text[i].color = Color.white;
        }

    }
}




