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
    public string UnitName { get { return _unitName; } set { _unitName = value; } }

    //유닛 레벨
    [SerializeField] protected int _unitLevel;
    public int UnitLevel { get { return _unitLevel; } set { _unitLevel = value; } }

    //유닛 최대 체력
    [SerializeField] protected int _maxHP;
    public int MaxHP { get { return _maxHP; } set { _maxHP = value; } }

    //유닛 현재 체력
    [SerializeField] protected int _currentHP;
    public int CurrentHP { get { return _currentHP; } set { _currentHP = value; } }

    [SerializeField] protected bool _isDead = false;
    public bool IsDead { get { return _isDead; } set { _isDead = value; } }

    protected virtual void Start()
    {
        SetFirstStatus();
    }
    protected virtual void SetFirstStatus()
    {
        _currentUnitBaseSTO.Set_UnitData(UnitBaseSTO);
        Set_UnitStat(this, _currentUnitBaseSTO);
    }

    public virtual void Hit(int attackPower)
    {
        if (All_Manager.instance.GameMode_M.isLive == true) return;

        CurrentHP -= attackPower;

        Check_Dead();
    }

    protected virtual bool Check_Dead()
    {
        if (CurrentHP <= 0)
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
        IsDead = true;
    }


    //유닛 스탯 세팅
    public abstract void Set_UnitStat(Unit_Base Unit, STO_UnitBase STO_Unit);
}
