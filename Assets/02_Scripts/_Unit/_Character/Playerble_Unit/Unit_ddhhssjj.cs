using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_ddhhssjj : Unit_Player
{
    protected override void Start()
    {
        base.Start();
        All_Manager.instance.UI_M.Update_Player_Unit_Current_HP((Current_HP / Max_HP), 0);
        All_Manager.instance.UI_M.Update_Player_Unit_Current_HP(Max_HP, Current_HP, 0);
    }

    protected override void SetFirstStatus()
    {
        base.SetFirstStatus();
    }

    public override void Hitted(int attackPower)
    {
        base.Hitted(attackPower);

        All_Manager.instance.UI_M.Update_Player_Unit_Current_HP((Current_HP / Max_HP), 0);
        All_Manager.instance.UI_M.Update_Player_Unit_Current_HP(Max_HP, Current_HP, 0);
    }

    protected override bool Check_Dead()
    {
        return base.Check_Dead();
    }

    protected override void Unit_Die()
    {
        base.Unit_Die();
    }

    public override void Set_UnitStat(Unit_Base Unit, STO_UnitBase STO_Unit)
    {
        base.Set_UnitStat(Unit, STO_Unit);
    }
}
