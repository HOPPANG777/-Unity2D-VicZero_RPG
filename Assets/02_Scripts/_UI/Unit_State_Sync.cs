using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Unit_State_Sync : MonoBehaviour
{

    public void Update_Unit_State_UI(List<Unit_Base> units, TeamType team)
    {
        for (int i = 0; i < units.Count; i++)
        {
            var unit = units[i];
            if (team == TeamType.ALLY)
            {
                if (i < All_Manager.instance.UI_M.Character_Current_HP_Image.Count && i < All_Manager.instance.UI_M.Character_HP_Text.Count)
                {
                    All_Manager.instance.UI_M.Character_Current_HP_Image[i].fillAmount = (float)unit.Current_HP / unit.Max_HP;
                    All_Manager.instance.UI_M.Character_HP_Text[i].text = unit.Current_HP.ToString() + "/" + unit.Max_HP.ToString() ;
                }
                if (i < All_Manager.instance.UI_M.Character_Current_SP_Image.Count && i < All_Manager.instance.UI_M.Character_SP_Text.Count)
                {
                    All_Manager.instance.UI_M.Character_Current_SP_Image[i].fillAmount = (float)unit.Current_SP / unit.Max_SP;
                    All_Manager.instance.UI_M.Character_SP_Text[i].text = unit.Current_SP.ToString() + "/" + unit.Max_SP.ToString();
                }
            }
            else
            {
                if (i < All_Manager.instance.UI_M.Enemy_Current_HP_Image.Count && i < All_Manager.instance.UI_M.Enemy_HP_Text.Count)
                {
                    All_Manager.instance.UI_M.Enemy_Current_HP_Image[i].fillAmount = (float)unit.Current_HP / unit.Max_HP;
                    All_Manager.instance.UI_M.Enemy_HP_Text[i].text = unit.Current_HP.ToString() + "/" + unit.Max_HP.ToString();
                }
            }
        }
    }
}
