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
                    All_Manager.instance.UI_M.Character_HP_Text[i].text = unit.Max_HP.ToString() + "/" + unit.Current_HP.ToString();
                }
                if (i < All_Manager.instance.UI_M.Character_Current_SP_Image.Count && i < All_Manager.instance.UI_M.Character_SP_Text.Count)
                {
                    All_Manager.instance.UI_M.Character_Current_SP_Image[i].fillAmount = (float)unit.Current_SP / unit.Max_SP;
                    All_Manager.instance.UI_M.Character_SP_Text[i].text = unit.Max_SP.ToString() + "/" + unit.Current_SP.ToString();
                }
            }
            else
            {
                if (i < All_Manager.instance.UI_M.Enemy_Current_HP_Image.Count && i < All_Manager.instance.UI_M.Enemy_HP_Text.Count)
                {
                    All_Manager.instance.UI_M.Enemy_Current_HP_Image[i].fillAmount = (float)unit.Current_HP / unit.Max_HP;
                    All_Manager.instance.UI_M.Enemy_HP_Text[i].text = unit.Max_HP.ToString() + "/" + unit.Current_HP.ToString();
                }
            }
        }
    }

    //플레이어 유닛의 현재 HP 이미지
    public void Update_Player_Unit_Current_HP(int p_FillAmount_Value, int Unit_Index)
    {
        All_Manager.instance.UI_M.Character_Current_HP_Image[Unit_Index].fillAmount = p_FillAmount_Value;
    }

    //에너미 유닛의 현재 HP 이미지
    public void Update_Enemy_Unit_Current_HP(int p_FillAmount_Value, int Unit_Index)
    {
        All_Manager.instance.UI_M.Enemy_Current_HP_Image[Unit_Index].fillAmount = p_FillAmount_Value;
    }

    //플레이어 유닛의 현재 HP 텍스트
    public void Update_Player_Unit_Current_HP(int p_Max_Value, int p_Min_Value, int Unit_Index)
    {
        All_Manager.instance.UI_M.Character_HP_Text[Unit_Index].text = p_Max_Value.ToString() + "/" + p_Min_Value.ToString();
    }

    //에너미 유닛의 현재 HP 텍스트
    public void Update_Enemy_Unit_Current_HP(int p_Max_Value, int p_Min_Value, int Unit_Index)
    {
        All_Manager.instance.UI_M.Enemy_HP_Text[Unit_Index].text = p_Max_Value.ToString() + "/" + p_Min_Value.ToString();
    }

    //플레이어 유닛의 현재 SP 이미지
    public void Update_Player_Unit_Current_SP(int p_FillAmount_Value, int Unit_Index)
    {
        All_Manager.instance.UI_M.Character_Current_SP_Image[Unit_Index].fillAmount = p_FillAmount_Value;
    }

    //플레이어 유닛의 현재 SP 텍스트
    public void Update_Player_Unit_Current_SP(int p_Max_Value, int p_Min_Value, int Unit_Index)
    {
        All_Manager.instance.UI_M.Character_SP_Text[Unit_Index].text = p_Max_Value.ToString() + "/" + p_Min_Value.ToString();
    }

}
