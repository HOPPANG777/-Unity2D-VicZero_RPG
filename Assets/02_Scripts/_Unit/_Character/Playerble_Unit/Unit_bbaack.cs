using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_bbaack : Unit_Player
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void SetFirstStatus()
    {
        base.SetFirstStatus();
    }

    public override void Hitted(int attackPower)
    {
        base.Hitted(attackPower);
    }

    protected override bool Check_Dead()
    {
        return base.Check_Dead();
    }

    protected override void UpdateStateUI()
    {
        base.UpdateStateUI();
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
