using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_ddhhssjj : Unit_Player
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
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

    protected override void Unit_Die()
    {
        base.Unit_Die();
    }

    protected override void UpdateStateUI()
    {
        base.UpdateStateUI();
    }

    public override void Player_Unit_Attack()
    {
        base.Player_Unit_Attack();
    }

    public override void Set_UnitStat(Unit_Base Unit, STO_UnitBase STO_Unit)
    {
        base.Set_UnitStat(Unit, STO_Unit);
    }

    public override void Set_Unit_Position()
    {
        base.Set_Unit_Position();
    }
    public override void Perform_Action(Unit_Base Attacker, Unit_Base Target, STO_Base_Act Act)
    {
        base.Perform_Action(Attacker, Target, Act);
    }
}
