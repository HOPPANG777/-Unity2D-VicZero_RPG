using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Unit_Interviewer : Unit_Enemy
{
    protected override void Start()
    {
        base.Start();
        All_Manager.instance.UI_M.Update_Enemy_Unit_Current_HP((Current_HP / Max_HP), 0);
        All_Manager.instance.UI_M.Update_Enemy_Unit_Current_HP(Max_HP, Current_HP, 0);
    }

    protected override void SetFirstStatus()
    {
        base.SetFirstStatus();
        Set_UnitStat(this, _currentUnitBaseSTO);
    }
    public override void Hitted(int attackPower)
    {
        base.Hitted(attackPower);

        All_Manager.instance.UI_M.Update_Enemy_Unit_Current_HP((Current_HP / Max_HP), 0);
        All_Manager.instance.UI_M.Update_Enemy_Unit_Current_HP(Max_HP, Current_HP, 0);
    }

    public override void Set_UnitStat(Unit_Base Unit, STO_UnitBase STO_Unit)
    {
        base.Set_UnitStat(Unit, STO_Unit);
    }

}
