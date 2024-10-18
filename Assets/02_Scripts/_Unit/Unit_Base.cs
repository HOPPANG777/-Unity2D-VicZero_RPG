using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 유닛 정보 : 이름, 레벨, 최대(현재)HP, 어택 파워, 디펜스 파워
[System.Serializable]
public struct UnitBase_Info
{
    public string unitName;
    public int unitHP;
    public int unitSpeed;
    public int attackPower;
    public int defensePower;
}

public class Unit_Base : MonoBehaviour, ITeamMember
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
    public UnitBase_Info UnitBase_Info { get { return _currentUnitBaseSTO.UnitInfo; } set { _currentUnitBaseSTO.UnitInfo = value; } }

    //유닛 레벨
    [SerializeField] protected int _unitLevel;
    public int UnitLevel { get { return _unitLevel; } set { _unitLevel = value; } }

    //유닛 최대 체력
    [SerializeField] protected int _maxHP;
    public int MaxHP { get { return _maxHP; } set { _maxHP = value; } }

    //유닛 현재 체력
    [SerializeField] protected int _currentHP;
    public int CurrentHP { get { return _currentHP; } set { _currentHP = value; } }


    
}
