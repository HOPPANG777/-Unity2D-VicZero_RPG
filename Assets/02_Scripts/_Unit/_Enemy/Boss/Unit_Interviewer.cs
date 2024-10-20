using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Unit_Interviewer : Unit_Enemy
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

    protected override void UpdateStateUI()
    {
        base.UpdateStateUI();
    }

    public override void Set_UnitStat(Unit_Base Unit, STO_UnitBase STO_Unit)
    {
        base.Set_UnitStat(Unit, STO_Unit);
    }

}
