using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Player : Unit_Base, IUnitAnimationState
{

    public STO_PlayerUnit PlayerUnitSTO { get { return _playerUnitSTO; } }
    [SerializeField] STO_PlayerUnit _playerUnitSTO;
    [SerializeField] protected STO_PlayerUnit _currentPlayerUnitSTO;
    public STO_PlayerUnit CurrentPlayerUnitSTO { get { return _currentPlayerUnitSTO; } }

    public Animation_State Anim_State { get { return _currentPlayerUnitSTO.Anim_State; } set { _currentPlayerUnitSTO.Anim_State = value; } }



    protected override void Start()
    {
        base.Start();
    }

    protected override void SetFirstStatus()
    {
        base.SetFirstStatus();
    }

    public override void Set_UnitStat(Unit_Base Unit, STO_UnitBase STO_Unit)
    {
        Unit.Unit_Name = STO_Unit.Unit_Name;
        Unit.UnitBase_Stat.unitHP = STO_Unit.UnitInfo[Unit_Level].unitHP;
        Unit.Max_HP = Unit.Current_HP = STO_Unit.UnitInfo[Unit_Level].unitHP;
        Unit.UnitBase_Stat.unitSpeed = STO_Unit.UnitInfo[Unit_Level].unitSpeed;
        Unit.UnitBase_Stat.attackPower = STO_Unit.UnitInfo[Unit_Level].attackPower;
        Unit.UnitBase_Stat.defensePower = STO_Unit.UnitInfo[Unit_Level].defensePower;
        Unit.UnitBase_Stat.unitSP = STO_Unit.UnitInfo[Unit_Level].unitSP;
        Unit.Max_SP = Unit.Current_SP = STO_Unit.UnitInfo[Unit_Level].unitSP;
    }
}
