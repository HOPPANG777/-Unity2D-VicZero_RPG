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
    [SerializeField] protected STO_Attack[] _attackAct;
    public STO_Attack[] Attack_Act { get { return _attackAct; } }

    [SerializeField] protected STO_Skill[] _skillAct;
    public STO_Skill[] Skill_Act { get { return _skillAct; } }

    [SerializeField] protected STO_Action[] _actionAct;
    public STO_Action[] Action_Act { get { return _actionAct; } }

    public TeamType TeamType { get { return _currentUnitBaseSTO.teamType; } set { _currentUnitBaseSTO.teamType = value; } }
    public UnitBase_Info UnitBase_Stat;

    // 유닛 애니메이터 컨트롤러
    public RuntimeAnimatorController Unit_Animator { get { return _currentUnitBaseSTO.AnimController; } set { _currentUnitBaseSTO.AnimController = value; } }

    // 유닛 애니메이션 상태
    [SerializeField] IUnitAnimationState _animState;
    public IUnitAnimationState Current_State { get { return _animState; } set { _animState = value; } }

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

    //유닛의 순서
    [SerializeField] protected int _unitIndex;
    public int Unit_Index { get { return _unitIndex; } set { _unitIndex = value; } }

    //유닛의 타겟
    public Unit_Base unitTarget = null;

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
        if (Current_State != null)
        {
            Current_State.Update_State(this);
        }
    }

    protected virtual void SetFirstStatus()
    {
        _currentUnitBaseSTO.Set_UnitData(UnitBaseSTO);
        Set_UnitStat(this, _currentUnitBaseSTO);
    }

    // 맞았을때
    public virtual void Hitted(int attackPower)
    {
        if (All_Manager.instance.GameMode_M.isLive == true) return;

        Set_State(new Take_Hit_State());

        var Temp_Defense = 100f / (100f + CurrentUnitBaseSTO.UnitInfo[Unit_Level].defensePower) * attackPower;

        int Temp_Defense_Int = Mathf.RoundToInt(Temp_Defense);

        Current_HP -= Temp_Defense_Int;

        UpdateStateUI();

        Check_Dead();

        All_Manager.instance.GameMode_M.Lost_or_Win();
    }

    protected virtual bool Check_Dead()
    {
        if (Current_HP <= 0)
        {
            Unit_Die();
            Set_State(new Death_State());
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

    // 유닛 상태 세팅 
    public void Set_State(IUnitAnimationState New_State)
    {
        if (Current_State != null)
        {
            Current_State.Exit_State(this);
        }

        Current_State = New_State;
        Current_State.Enter_State(this);
    }

    #region
    public void Unit_Animation_Play(Animation_State State)
    {
        switch (State)
        {
            case Animation_State.IDLE:
                Set_State(new Idle_State());
                break;
            case Animation_State.ATK_1:
                Set_State(new Atk_1_State());
                break;
            case Animation_State.ATK_2:
                Set_State(new Atk_2_State());
                break;
            case Animation_State.ATK_3:
                Set_State(new Atk_3_State());
                break;
            case Animation_State.Skill_1:
                Set_State(new Skill_1_State());
                break;
            case Animation_State.Skill_2:
                Set_State(new Skill_2_State());
                break;
            case Animation_State.SP_ATK:
                Set_State(new Sp_Atk_State());
                break;
            case Animation_State.ROLL:
                Set_State(new Roll_State());
                break;
            case Animation_State.DEFEND:
                Set_State(new Defend_State());
                break;
            case Animation_State.MOVE:
                Set_State(new Move_State());
                break;
            case Animation_State.JUMP:
                Set_State(new Jump_State());
                break;
            case Animation_State.TAKE_HIT:
                Set_State(new Take_Hit_State());
                break;
            case Animation_State.DEATH:
                Set_State(new Death_State());
                break;
        }
    }
    #endregion

    // 유닛 스탯 세팅
    public abstract void Set_UnitStat(Unit_Base Unit, STO_UnitBase STO_Unit);

    // 유닛 배치 포지션 세팅
    public abstract void Set_Unit_Position();

    public abstract void Perform_Action(Unit_Base Attacker, Unit_Base Target, STO_Base_Act Act);
}
