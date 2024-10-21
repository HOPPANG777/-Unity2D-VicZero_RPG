using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Unit_Player : Unit_Base
{
    public STO_PlayerUnit PlayerUnitSTO { get { return _playerUnitSTO; } }
    [SerializeField] STO_PlayerUnit _playerUnitSTO;
    [SerializeField] protected STO_PlayerUnit _currentPlayerUnitSTO;
    public STO_PlayerUnit CurrentPlayerUnitSTO { get { return _currentPlayerUnitSTO; } }

    protected override void Start()
    {
        base.Start();
        Set_Animation(Animation_State.IDLE);
    }

    public override void Hitted(int attackPower)
    {
        base.Hitted(attackPower);
        Set_Animation(Animation_State.TAKE_HIT);
        Set_Animation(Animation_State.IDLE);
    }

    protected override void SetFirstStatus()
    {
        base.SetFirstStatus();
    }

    protected override void UpdateStateUI()
    {
        base.UpdateStateUI();
    }

    // 유닛 애니메이션 세팅
    public virtual void Set_Animation(Animation_State State)
    {
        switch (State)
        {
            case Animation_State.IDLE:
                {
                    Set_Animation_Trigger("Idle");
                }
                break;
            case Animation_State.ATK_1:
                {
                    Set_Animation_Trigger("Atk_1");
                }
                break;
            case Animation_State.ATK_2:
                {
                    Set_Animation_Trigger("Atk_2");
                }
                break;
            case Animation_State.ATK_3:
                {
                    Set_Animation_Trigger("Atk_3");
                }
                break;
            case Animation_State.Skill_1:
                {
                    Set_Animation_Trigger("Skill_1");
                }
                break;
            case Animation_State.Skill_2:
                {
                    Set_Animation_Trigger("Skill_2");
                }
                break;
            case Animation_State.SP_ATK:
                {
                    Set_Animation_Trigger("Sp_Atk");
                }
                break;
            case Animation_State.ROLL:
                {
                    Set_Animation_Trigger("Roll");
                }
                break;
            case Animation_State.DEFEND:
                {
                    Set_Animation_Trigger("Defend");
                }
                break;
            case Animation_State.MOVE:
                {
                    Set_Animation_Trigger("Move");
                }
                break;
            case Animation_State.JUMP:
                {
                    Set_Animation_Trigger("Jump");
                }
                break;
            case Animation_State.TAKE_HIT:
                {
                    Set_Animation_Trigger("Take_Hit");
                }
                break;
            case Animation_State.DEATH:
                {
                    Set_Animation_Trigger("Death");
                }
                break;
        }

    }

    public virtual void Player_Unit_Attack()
    {
        All_Manager.instance.UI_M.Unit_Selector_Arrow.Current_Unit.transform.position = All_Manager.instance.UI_M.Unit_Selector_Arrow.Current_Enemy.transform.position + new Vector3(2.75f, 0, 0);

        Set_Animation(Animation_State.ATK_1);
        All_Manager.instance.UI_M.Unit_Selector_Arrow.Current_Enemy.Hitted(_currentUnitBaseSTO.UnitInfo[Unit_Level].attackPower);
        Set_Animation(Animation_State.IDLE);
    }


    public override void Set_Animation_Trigger(string trigger)
    {
        base.Set_Animation_Trigger(trigger);
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
        Unit.unitSR.sprite = STO_Unit.UnitSprite;
        Unit.unitAnimator.runtimeAnimatorController = STO_Unit.AnimController;
        Unit.unitSR.drawMode = SpriteDrawMode.Sliced;
        Unit.unitSR.flipX = true;
        Unit.unitSR.size = new Vector2(11.52f, 5.12f);
        Unit.unitBC.size = new Vector2(2.0f, 2.5f);
        Unit.unitBC.offset = new Vector2(0.0f, -1.3f);
        Set_Unit_Position();
    }

    public override void Set_Unit_Position()
    {
        var Units = All_Manager.instance.GameMode_M.Player_List;

        for (int i = 0; i < Units.Count; i++)
        {
            if (i < Units.Count)
            {
                Units[i].transform.position = All_Manager.instance.Resource_M.Player_Unit_Set_Position[i] + new Vector3(0, 0, _currentPlayerUnitSTO.UnitSetPositionZ);
            }
        }
    }
}
