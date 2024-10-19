using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Enemy : Unit_Base, IUnitAnimationState
{
    public STO_EnemyUnit EnemyUnitSTO { get { return _enemyUnitSTO; } }
    [SerializeField] STO_EnemyUnit _enemyUnitSTO;
    [SerializeField] protected STO_EnemyUnit _currentEnemyUnitSTO;
    public STO_EnemyUnit CurrentEnemyUnitSTO { get { return _currentEnemyUnitSTO; } }

    public Animation_State Anim_State { get { return _currentEnemyUnitSTO.Anim_State; } set { _currentEnemyUnitSTO.Anim_State = value; } }


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

    public override void Set_UnitStat(Unit_Base Unit, STO_UnitBase STO_Unit)
    {
        Unit.Unit_Name = STO_Unit.Unit_Name; 
        Unit.UnitBase_Stat.unitHP = STO_Unit.UnitInfo[Unit_Level].unitHP; 
        Unit.Max_HP = Unit.Current_HP = STO_Unit.UnitInfo[Unit_Level].unitHP;
        Unit.UnitBase_Stat.unitSpeed = STO_Unit.UnitInfo[Unit_Level].unitSpeed;
        Unit.UnitBase_Stat.attackPower = STO_Unit.UnitInfo[Unit_Level].attackPower;
        Unit.UnitBase_Stat.defensePower = STO_Unit.UnitInfo[Unit_Level].defensePower;
    }
}
