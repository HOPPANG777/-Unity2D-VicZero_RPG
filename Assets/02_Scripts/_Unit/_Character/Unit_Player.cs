using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Player : Unit_Base
{
    public enum Anim_State
    { 
        IDLE,
        ATK_1,
        ATK_2,
        ATK_3,
        SP_ATK,
        ROLL,
        RUN,
        DEFEND,
        TAKE_HIT,
        DEATH
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void SetFirstStatus()
    {
        base.SetFirstStatus();
    }


    public virtual void Check_State(Anim_State CurrentState)
    {
        switch (CurrentState)
        {
            case Anim_State.IDLE:
                {

                }
                break;
            case Anim_State.ATK_1:
                {

                }
                break;
            case Anim_State.ATK_2:
                {

                }
                break;
            case Anim_State.ATK_3:
                {

                }
                break;
            case Anim_State.SP_ATK:
                {

                }
                break;
            case Anim_State.ROLL:
                {

                }
                break;
            case Anim_State.RUN:
                {

                }
                break;
            case Anim_State.DEFEND:
                {

                }
                break;
            case Anim_State.TAKE_HIT:
                {

                }
                break;
            case Anim_State.DEATH:
                {

                }
                break;
        }
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
