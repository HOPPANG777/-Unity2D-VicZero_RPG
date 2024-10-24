using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Unit_Enemy : Unit_Base
{
    [Header("Enemy")]
    [SerializeField] protected STO_EnemyUnit _currentEnemyUnitSTO;
    public STO_EnemyUnit CurrentEnemyUnitSTO { get { return _currentEnemyUnitSTO; } set { _currentEnemyUnitSTO = value; } }


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

    protected override void UpdateStateUI()
    {
        base.UpdateStateUI();
    }

    protected override bool Check_Dead()
    {
        return base.Check_Dead();
    }

    protected override void Unit_Die()
    {
        base.Unit_Die();
    }

    // 에너미 유닛 사망시
    protected void Enemy_Die()
    {
        // 필요 : 플레이어에 경험치 획득 함수, 플레이어 경험치 최대량 과 경험치 바
        // 에너미 유닛의 로직중 코루틴이 들어갔다면 그걸 멈출게 필요할것이고.
    }

    // 에너미 유닛 공격
    public virtual void Enemy_Unit_Attack()
    {
        
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

    public override void Perform_Action(Unit_Base Attacker, Unit_Base Target, STO_Base_Act Act)
    {
        //if (All_Manager.instance.GameMode_M.Turn_State == GameMode_Manager.Battle_State.ENEMY_TURN)
        {
            Debug.Log("Perform_Action_Enemy");

            All_Manager.instance.Resource_M.Unit_Controller.Unit_Execute_Act(Attacker, Target, Act);

            // 타겟이 사망했을 경우
            if (Target.Is_Dead)
            {
                // 새로운 타겟 선택
                List<Unit_Base> availableTargets = Attacker.TeamType == TeamType.ALLY ? All_Manager.instance.GameMode_M.Enemy_List : All_Manager.instance.GameMode_M.Player_List;
                availableTargets = availableTargets.FindAll(unit => !unit.Is_Dead);

                if (availableTargets.Count > 0)
                {
                    Target = availableTargets[0]; // 다른 타겟으로 변경
                    Perform_Action(Attacker, Target, Act);
                }
            }

            //All_Manager.instance.UI_M.Unit_Selector_Arrow.Current_Unit = null;
            //All_Manager.instance.UI_M.Unit_Selector_Arrow.Current_Enemy = null;
        }
    }

}
