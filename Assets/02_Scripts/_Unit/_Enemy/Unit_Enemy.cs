using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Enemy : Unit_Base
{
    public STO_EnemyUnit EnemyUnitSTO { get { return _enemyUnitSTO; } }
    [SerializeField] STO_EnemyUnit _enemyUnitSTO;
    [SerializeField] protected STO_EnemyUnit _currentEnemyUnitSTO;
    public STO_EnemyUnit CurrentEnemyUnitSTO { get { return _currentEnemyUnitSTO; } }


    protected override void Start()
    {
        base.Start();
        Set_Animation(Animation_State.IDLE);
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
    
    public override void Set_Animation_Trigger(string trigger)
    {
        base.Set_Animation_Trigger(trigger);
    }

    // 에너미 유닛 공격
    public virtual void Enemy_Unit_Attack()
    {
        
    }

    // 에너미 유닛 사망시
    protected void Enemy_Die()
    {
        // 필요 : 플레이어에 경험치 획득 함수, 플레이어 경험치 최대량 과 경험치 바
        // 에너미 유닛의 로직중 코루틴이 들어갔다면 그걸 멈출게 필요할것이고.
    }

    public override void Set_UnitStat(Unit_Base Unit, STO_UnitBase STO_Unit)
    {
        Unit.Unit_Name = STO_Unit.Unit_Name; 
        Unit.UnitBase_Stat.unitHP = STO_Unit.UnitInfo[Unit_Level].unitHP; 
        Unit.Max_HP = Unit.Current_HP = STO_Unit.UnitInfo[Unit_Level].unitHP;
        Unit.UnitBase_Stat.unitSpeed = STO_Unit.UnitInfo[Unit_Level].unitSpeed;
        Unit.UnitBase_Stat.attackPower = STO_Unit.UnitInfo[Unit_Level].attackPower;
        Unit.UnitBase_Stat.defensePower = STO_Unit.UnitInfo[Unit_Level].defensePower;
        Unit.unitSR.sprite = STO_Unit.UnitSprite;
        Unit.unitAnimator.runtimeAnimatorController = STO_Unit.AnimController;
        Unit.unitSR.drawMode = SpriteDrawMode.Sliced;
        //Unit.unitSR.flipX = true;
        Unit.unitSR.size = new Vector2(11.52f, 5.12f);
        Unit.unitBC.size = new Vector2(2.0f, 2.5f);
        Unit.unitBC.offset = new Vector2(0.0f, -1.3f);
    }

    public override void Set_Unit_Position()
    {

    }
}
