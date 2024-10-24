using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 메뉴에 볼수 있도록 해주는것
[CreateAssetMenu(fileName = "Unit_Data", menuName = "Unit_Data", order = 0)]
public class STO_UnitBase : ScriptableObject
{
    [Header("UnitBase_Date")]
    // 유닛 사망시 사운드 이펙트
    [SerializeField] AudioClip _dieSound;
    public AudioClip DieSound { get { return _dieSound; } set { _dieSound = value; } }

    //유닛 애니메이터 컨트롤러
    [SerializeField] RuntimeAnimatorController _animController;
    public RuntimeAnimatorController AnimController { get { return _animController; } set { _animController = value; } }

    //유닛 스프라이트
    [SerializeField] Sprite _unitSprite;
    public Sprite UnitSprite { get { return _unitSprite; } set { _unitSprite = value; } }
     
    // 유닛 정보 스트럭트
    [SerializeField] protected UnitBase_Info[] _unitInfo;
    public UnitBase_Info[] UnitInfo { get { return _unitInfo; } set { _unitInfo = value; } }

    // 유닛 팀 타입
    [SerializeField] TeamType _teamType;
    public TeamType teamType { get { return _teamType; } set { _teamType = value; } }

    // 유닛 이름
    [SerializeField] protected string _unitName;
    public string Unit_Name { get { return _unitName; } set { _unitName = value; } }

    [SerializeField] private float _maxATB = 100.0f;
    public float Max_ATB { get { return _maxATB; } set { _maxATB = value; } }

    public virtual void Set_UnitData(STO_UnitBase STO_Unit)
    {
        this._dieSound = STO_Unit.DieSound;

        this._animController = STO_Unit.AnimController;
        this._unitSprite = STO_Unit.UnitSprite;

        this._unitName = STO_Unit.Unit_Name;

        this._teamType = STO_Unit.teamType;
    }
}
