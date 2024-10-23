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
    public List<Unit_Enemy> Selected_Enemies = new List<Unit_Enemy>(); // 선택된 적 유닛 목록

    private IEnumerator Temp_Blink_Coroutine;

    private void Start()
    {
        if (!All_Manager.instance.Setting_M.Game_Stop && All_Manager.instance.Setting_M.Stage_In)
        {
            // 초기 상태에서는 화살표와 컨트롤 패널 비활성화
            All_Manager.instance.UI_M.Choice_Controll_Panel.gameObject.SetActive(false);
            Current_Arrow = Instantiate(Arrow_Indicator_Prefab);
            Current_Arrow.SetActive(false);
        }
    }

    private void Update()
    {
        if (!All_Manager.instance.Setting_M.Game_Stop && All_Manager.instance.Setting_M.Stage_In)
        {
            Wait_For_Player_Input();
        }
    }

    public void Wait_For_Player_Input()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 클릭
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hitCollider = Physics2D.OverlapPoint(mousePos);

            if (hitCollider != null)
            {
                Unit_Player selectedUnit = hitCollider.GetComponent<Unit_Player>();

                if (selectedUnit != null) // 유닛이 클릭되었을 때
                {
                    Select_Player_Unit(selectedUnit);
                }
                else if (Current_Unit != null) // 플레이어 유닛이 선택된 후 적 유닛 선택
                {
                    Unit_Enemy selectedEnemy = hitCollider.GetComponent<Unit_Enemy>();
                    if (selectedEnemy != null)
                    {
                        Select_Enemy_Unit(selectedEnemy);
                    }
                }
            }
        }
    }

    public void Select_Player_Unit(Unit_Player unit)
    {
        // 이전에 선택된 유닛의 화살표 숨기기
        if (Current_Unit != null)
        {
            Current_Arrow.SetActive(false);
            foreach (var nameText in All_Manager.instance.UI_M.Character_Name_Text)
            {
                nameText.color = Color.white;
            }
        }

        // 새로운 유닛 선택
        Current_Unit = unit;

        var playerNameList = All_Manager.instance.UI_M.Character_Name_Text;
        TextMeshProUGUI currentPlayerName = null;

        foreach (var nameText in playerNameList)
        {
            if (nameText.text.Contains(unit.Unit_Name))
            {
                currentPlayerName = nameText;
                break;
            }
        }

        if (currentPlayerName != null)
        {
            currentPlayerName.color = Color.yellow;
        }

        // 화살표를 현재 선택된 유닛 머리 위로 이동하고 노란색으로 설정한 후 활성화
        Current_Arrow.transform.position = Current_Unit.transform.position + new Vector3(0, -0.3f, 0);
        Current_Arrow.GetComponent<SpriteRenderer>().color = Color.yellow;
        Current_Arrow.SetActive(true);

        // 컨트롤 패널 비활성화 (적 선택 전까지)
        All_Manager.instance.UI_M.Choice_Controll_Panel.gameObject.SetActive(false);
    }

    public void Select_Enemy_Unit(Unit_Enemy unit)
    {
        // 이미 선택된 적 유닛인지 확인
        if (Selected_Enemies.Contains(unit))
        {
            // 이미 선택된 경우 선택 해제
            Selected_Enemies.Remove(unit);
            Set_Unit_Alpha(unit, 1.0f);
            if (Temp_Blink_Coroutine != null)
            {
                StopCoroutine(Temp_Blink_Coroutine);
            }
            unit.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            // 새로운 적 유닛 선택
            Selected_Enemies.Add(unit);
            Set_Unit_Alpha(unit, 0.5f);
            Blink_Coroutine(unit);
        }

        // 화살표를 적 유닛 머리 위로 이동하고 빨간색으로 설정한 후 활성화
        Current_Arrow.transform.position = unit.transform.position + new Vector3(0, 1.0f, 0);
        Current_Arrow.GetComponent<SpriteRenderer>().color = Color.red;
        Current_Arrow.SetActive(true);

        // 컨트롤 패널 활성화 (적 유닛이 하나 이상 선택된 경우)
        All_Manager.instance.UI_M.Choice_Controll_Panel.gameObject.SetActive(Selected_Enemies.Count > 0);
    }

    void Blink_Coroutine(Unit_Enemy unit)
    {
        Temp_Blink_Coroutine = Blink_Unit(unit);

        StartCoroutine(Temp_Blink_Coroutine);
    }

    IEnumerator Blink_Unit(Unit_Enemy unit)
    {
        SpriteRenderer renderer = unit.gameObject.GetComponent<SpriteRenderer>();
        while (true)
        {
            renderer.enabled = !renderer.enabled;
            yield return new WaitForSeconds(0.5f); // 깜박이는 주기 설정
        }
    }

    void Set_Unit_Alpha(Unit_Enemy unit, float alpha)
    {
        Color unitColor = unit.gameObject.GetComponent<SpriteRenderer>().color;
        unitColor.a = alpha;
        unit.gameObject.GetComponent<SpriteRenderer>().color = unitColor;
    }
    


}


