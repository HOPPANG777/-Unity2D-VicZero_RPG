using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// 유닛 정보 : 이름, 레벨, 최대(현재)HP, 어택 파워, 디펜스 파워
[System.Serializable]
public struct UnitBase_Info
{
    public int unitHP;
    public int unitSpeed;
    public int attackPower;
    public int defensePower;
    public int unitSP;
}

public abstract class Unit_Base : MonoBehaviour, ITeamMember
{
    [Header("Unit_Base")]
    public Rigidbody2D unitRB;
    public BoxCollider2D unitBC;
    public Animator unitAnimator;
    public SpriteRenderer unitSR;

    public STO_UnitBase UnitBaseSTO { get { return _unitBaseSTO; } }
    [SerializeField] STO_UnitBase _unitBaseSTO;
    [SerializeField] protected STO_UnitBase _currentUnitBaseSTO;
    public STO_UnitBase CurrentUnitBaseSTO { get { return _currentUnitBaseSTO; } }

    // 행동
    [SerializeField] protected STO_Base_Act[] _Act;
    public STO_Base_Act[] Act { get { return _Act; } }

    public TeamType TeamType { get { return _currentUnitBaseSTO.teamType; } set { _currentUnitBaseSTO.teamType = value; } }
    public UnitBase_Info UnitBase_Stat;
    public float Max_ATB { get { return _currentUnitBaseSTO.Max_ATB; } set { _currentUnitBaseSTO.Max_ATB = value; } }

    // 유닛 애니메이터 컨트롤러
    public RuntimeAnimatorController Unit_Animator { get { return _currentUnitBaseSTO.AnimController; } set { _currentUnitBaseSTO.AnimController = value; } }

    // 유닛 애니메이션 상태
    [SerializeField] Unit_State _animState;
    public Unit_State Current_State { get { return _animState; } set { _animState = value; } }

    //유닛 이름
    [SerializeField] protected string _unitName;
    public string Unit_Name { get { return _unitName; } set { _unitName = value; } }

    //유닛 레벨
    [SerializeField] protected int _unitLevel;
    public int Unit_Level { get { return _unitLevel; } set { _unitLevel = value; } }

    //유닛 최대 체력
    [SerializeField] protected int _maxHP;
    public int Max_HP { get { return _maxHP; } set { _maxHP = value; } }

    //유닛 현재 체력
    [SerializeField] protected int _currentHP;
    public int Current_HP { get { return _currentHP; } set { _currentHP = value; } }

    //유닛 최대 SP
    [SerializeField] protected int _maxSP;
    public int Max_SP { get { return _maxSP; } set { _maxSP = value; } }

    //유닛 현재 SP
    [SerializeField] protected int _currentSP;
    public int Current_SP { get { return _currentSP; } set { _currentSP = value; } }

    //유닛의 사망 판정
    [SerializeField] protected bool _isDead = false;
    public bool Is_Dead { get { return _isDead; } }

    //유닛의 타겟
    public Unit_Base unitTarget = null;

    public float Current_ATB;
    public bool isReadyToAct;

    protected virtual void Start()
    {
        unitSR = this.AddComponent<SpriteRenderer>();

        unitRB = this.AddComponent<Rigidbody2D>();
        unitRB.bodyType = RigidbodyType2D.Kinematic;

        unitBC = this.AddComponent<BoxCollider2D>();
        unitBC.isTrigger = true;

        unitAnimator = this.AddComponent<Animator>();

        SetFirstStatus();

        UpdateStateUI();
    }

    protected virtual void Update()
    {
        Charge_ATB();
    }

    protected virtual void SetFirstStatus()
    {
        _currentUnitBaseSTO.Set_UnitData(UnitBaseSTO);
        Set_UnitStat(this, _currentUnitBaseSTO);
        
    }

    protected virtual void Charge_ATB()
    {

        if (!isReadyToAct)
        {
            Current_ATB += UnitBase_Stat.unitSpeed * Time.deltaTime;
            if (Current_ATB >= Max_ATB)
            {
                Current_ATB = Max_ATB;
                isReadyToAct = true; // 게이지가 가득 차면 행동 가능
            }
        }
 
    }

    protected virtual void Take_Action()
    {
        if (isReadyToAct)
        {
            // 행동 선택
            
        }
    }

    protected virtual void Reset_ATB()
    {
        Current_ATB = 0;
        isReadyToAct = false;
    }


    // 맞았을때
    public virtual void Hitted(int attackPower)
    {
        if (Current_HP < 0)
        {
            Unit_Die();
            Current_HP = 0;
        }
        else
        {
            if (All_Manager.instance.GameMode_M.isLive == false) return;

            var Temp_Defense = 100f / (100f + CurrentUnitBaseSTO.UnitInfo[Unit_Level].defensePower) * attackPower;

            int Temp_Defense_Int = Mathf.RoundToInt(Temp_Defense);

            Current_HP -= Temp_Defense_Int;

            UpdateStateUI();
        }
    }

    protected virtual bool Check_Dead()
    {
        if (Current_HP < 0)
        {
            Unit_Die();
            Current_HP = 0;
            return true;
        }
        else
        {
            return false;
        }
    }

    // 유닛 사망
    protected virtual void Unit_Die()
    {
        _isDead = true;
    }

    // 업데이트 상태 UI
    protected virtual void UpdateStateUI()
    {
        if (TeamType == TeamType.ALLY)
        {
            All_Manager.instance.UI_M.State_Sync.Update_Unit_State_UI(All_Manager.instance.GameMode_M.Player_List, _currentUnitBaseSTO.teamType);
        }
        else if (TeamType == TeamType.ENEMY)
        {
            All_Manager.instance.UI_M.State_Sync.Update_Unit_State_UI(All_Manager.instance.GameMode_M.Enemy_List, _currentUnitBaseSTO.teamType);
        }
    }

    protected virtual void Set_State(Unit_State New_State)
    {
        Current_State = New_State;
        Current_State.Handle();
    }

    #region
    public void Easy_State(Unit_Base Unit, Animation_State State)
    {
        switch (State)
        {
            case Animation_State.Idle:
                Set_State(new Idle_State(Unit.unitAnimator));
                break;
            case Animation_State.Atk_1:
                Set_State(new Atk_1_State(Unit.unitAnimator));
                break;
            case Animation_State.Atk_2:
                Set_State(new Atk_2_State(Unit.unitAnimator));
                break;
            case Animation_State.Atk_3:
                Set_State(new Atk_3_State(Unit.unitAnimator));
                break;
            case Animation_State.Skill_1:
                Set_State(new Skill_1_State(Unit.unitAnimator));
                break;
            case Animation_State.Skill_2:
                Set_State(new Skill_2_State(Unit.unitAnimator));
                break;
            case Animation_State.Sp_Atk:
                Set_State(new Sp_Atk_State(Unit.unitAnimator));
                break;
            case Animation_State.Roll:
                Set_State(new Roll_State(Unit.unitAnimator));
                break;
            case Animation_State.Defend:
                Set_State(new Defend_State(Unit.unitAnimator));
                break;
            case Animation_State.Move:
                Set_State(new Move_State(Unit.unitAnimator));
                break;
            case Animation_State.Jump:
                Set_State(new Jump_State(Unit.unitAnimator));
                break;
            case Animation_State.Take_Hit:
                Set_State(new Take_Hit_State(Unit.unitAnimator));
                break;
            case Animation_State.Death:
                Set_State(new Death_State(Unit.unitAnimator));
                break;
        }
    }
    #endregion

    // 유닛 스탯 세팅
    public abstract void Set_UnitStat(Unit_Base Unit, STO_UnitBase STO_Unit);

    // 유닛 배치 포지션 세팅
    public abstract void Set_Unit_Position();

    // 다음 액션
    public virtual void Perform_Action(Unit_Base Attacker, Unit_Base Target, STO_Base_Act Act)
    {

        if (isReadyToAct)
        {
            Easy_State(Attacker, Act.Anim_State);

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

            All_Manager.instance.UI_M.Unit_Selector_Arrow.Current_Unit = null;
            All_Manager.instance.UI_M.Unit_Selector_Arrow.Current_Enemy = null;

            // 행동 수행 로직
            Current_ATB = 0;
            isReadyToAct = false; // 행동을 수행한 후 ATB를 초기화
        }
    }
}
