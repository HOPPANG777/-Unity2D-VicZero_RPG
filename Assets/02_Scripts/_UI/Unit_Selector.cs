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
                Update_Unit_Selector();
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
                        Select_Enemy_Unit(Selected_Enemy);
                    }
                }
            }
        }
    }

    void Select_Player_Unit(Unit_Player Unit)
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

        // 화살표를 현재 선택된 유닛 머리 위로 이동하고 활성화
        Current_Arrow.transform.position = Current_Unit.transform.position + new Vector3(0, -0.3f, 0);
        Current_Arrow.SetActive(true);

        // 컨트롤 패널 비활성화 (적 선택 전까지)
        All_Manager.instance.UI_M.Choice_Controll_Panel.gameObject.SetActive(false);
    }

    void Select_Enemy_Unit(Unit_Enemy Unit)
    {
        // 이전에 선택된 적 유닛의 화살표 숨기기
        if (Current_Enemy != null)
        {
            Current_Arrow.SetActive(false);
        }

        // 새로운 적 유닛 선택
        Current_Enemy = Unit;

        Current_Arrow.transform.position = Current_Enemy.transform.position + new Vector3(0, 1.0f, 0);

        Current_Arrow.SetActive(true);

        // 컨트롤 패널 활성화
        All_Manager.instance.UI_M.Choice_Controll_Panel.gameObject.SetActive(true);
    }
}
