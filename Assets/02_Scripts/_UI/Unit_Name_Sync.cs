using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Unit_Name_Sync : MonoBehaviour
{
    private void Start()
    {
        if (All_Manager.instance.Setting_M.Game_Stop == false)
        {
            if (All_Manager.instance.Setting_M.Stage_In == true)
            {
                Set_Unit_Name();
            }
        }
        else
        {

        }
    }

    public void Set_Unit_Name()
    {
        // 모든 UI 패널 비활성화
        for (int i = 0; i < All_Manager.instance.UI_M.Player_Unit_Panel.Count; i++)
        {
            All_Manager.instance.UI_M.Player_Unit_Panel[i].gameObject.SetActive(false);
        }

        // 필드에 있는 유닛에 맞게 UI 패널 활성화 및 정보 동기화
        for (int i = 0; i < All_Manager.instance.GameMode_M.Player_List.Count; i++)
        {
            if (i < All_Manager.instance.UI_M.Player_Unit_Panel.Count)
            {
                Unit_Base Unit = All_Manager.instance.GameMode_M.Player_List[i];
                Canvas Panel = All_Manager.instance.UI_M.Player_Unit_Panel[i];

                // UI 패널 활성화
                Panel.gameObject.SetActive(true);

                // 유닛 정보를 UI에 동기화
                Update_Unit_Name_Panel(Panel, Unit.GetComponent<Unit_Player>());
            }
        }

        // 모든 UI 패널 비활성화
        for (int i = 0; i < All_Manager.instance.UI_M.Enemy_Unit_Panel.Count; i++)
        {
            All_Manager.instance.UI_M.Enemy_Unit_Panel[i].gameObject.SetActive(false);
        }

        // 필드에 있는 유닛에 맞게 UI 패널 활성화 및 정보 동기화
        for (int i = 0; i < All_Manager.instance.GameMode_M.Enemy_List.Count; i++)
        {
            if (i < All_Manager.instance.UI_M.Enemy_Unit_Panel.Count)
            {
                Unit_Base Unit = All_Manager.instance.GameMode_M.Enemy_List[i];
                Canvas Panel = All_Manager.instance.UI_M.Enemy_Unit_Panel[i];

                // UI 패널 활성화
                Panel.gameObject.SetActive(true);

                // 유닛 정보를 UI에 동기화
                Update_Unit_Name_Panel(Panel, Unit.GetComponent<Unit_Enemy>());
            }
        }
    }

    private void Update_Unit_Name_Panel(Canvas Panel, Unit_Base Unit)
    {
        // 이름 텍스트 업데이트
        TextMeshProUGUI Name = null;
        
        for (int i = 0; i < Panel.transform.childCount; i++)
        {
            var Child = Panel.transform.GetChild(i);
            if (Child.name.Contains("Name_Text"))
            {
                Name = Child.GetComponent<TextMeshProUGUI>();
                if (Name != null)
                {
                    break; // 원하는 오브젝트를 찾았으므로 루프 종료
                }
            }
        }

        // 이후 Name 접근하여 텍스트를 업데이트할 수 있습니다.
        if (Name != null)
        {
            Name.text = Unit.CurrentUnitBaseSTO.Unit_Name;
        }

        // 추가적인 정보 업데이트가 필요한 경우 여기에 추가
    }

}
