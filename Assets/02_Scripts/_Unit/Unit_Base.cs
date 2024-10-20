using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] protected BoxCollider2D unitBC;
    [SerializeField] protected Animator unitAnimator;

    public STO_UnitBase UnitBaseSTO { get { return _unitBaseSTO; } }
    [SerializeField] STO_UnitBase _unitBaseSTO;
    [SerializeField] protected STO_UnitBase _currentUnitBaseSTO;
    public STO_UnitBase CurrentUnitBaseSTO { get { return _currentUnitBaseSTO; } }

    public TeamType TeamType { get { return _currentUnitBaseSTO.teamType; } set { _currentUnitBaseSTO.teamType = value; } }
    public UnitBase_Info UnitBase_Stat;

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
    public bool Is_Dead { get { return _isDead; } set { _isDead = value; } }

    //유닛의 순서
    [SerializeField] protected int _unitIndex;
    public int Unit_Index { get { return _unitIndex; } set { _unitIndex = value; } }
    
    protected virtual void Start()
    {
        SetFirstStatus();

        UpdateStateUI();
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

        var Temp_Defense = 100f / (100f + CurrentUnitBaseSTO.UnitInfo[Unit_Level].defensePower) * attackPower;

        int Temp_Defense_Int = Mathf.RoundToInt(Temp_Defense);

        Current_HP -= Temp_Defense_Int;

        UpdateStateUI();

        Check_Dead();
    }

    protected virtual bool Check_Dead()
    {
        if (Current_HP <= 0)
        {
            Unit_Die();
            return true;
        }
        else
        {
            return false;
        }
    }

    protected virtual void Unit_Die()
    {
        Is_Dead = true;
    }

    protected virtual void UpdateStateUI()
    {
        if (TeamType == TeamType.ALLY)
        {
            All_Manager.instance.UI_M.State_Sync.Update_Unit_State_UI(_currentUnitBaseSTO.Unit_Index, Current_HP, Max_HP, _currentUnitBaseSTO.teamType, Current_SP, Max_SP);
        }
        else if (TeamType == TeamType.ENEMY)
        {
            All_Manager.instance.UI_M.State_Sync.Update_Unit_State_UI(_currentUnitBaseSTO.Unit_Index, Current_HP, Max_HP, _currentUnitBaseSTO.teamType, Current_SP, Max_SP);
        }
    }


    //유닛 스탯 세팅
    public abstract void Set_UnitStat(Unit_Base Unit, STO_UnitBase STO_Unit);
}
