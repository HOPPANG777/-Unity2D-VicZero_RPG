using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 메뉴에 볼수 있도록 해주는것
[CreateAssetMenu(fileName = "UnitData", menuName = "UnitData", order = 0)]
public class STO_UnitBase : ScriptableObject
{
    [Header("UnitBase_Date")]
    // 유닛 사망시 사운드 이펙트
    [SerializeField] AudioClip _dieSound;
    public AudioClip DieSound { get { return _dieSound; } set { _dieSound = value; } }

    // 유닛 정보 스트럭트
    [SerializeField] protected UnitBase_Info _unitInfo;
    public UnitBase_Info UnitInfo { get { return _unitInfo; } set { _unitInfo = value; } }

    // 유닛 팀 타입
    [SerializeField] TeamType _teamType;
    public TeamType teamType { get { return _teamType; } set { _teamType = value; } }


    virtual public void Set_UnitData(STO_UnitBase STO_Unit)
    {
        
    }

}
