using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player_Data", menuName = "Unit_Data/Player_Data", order = 1)]
public class STO_PlayerUnit : STO_UnitBase
{
    [Header("STO_PlayerUnit")]
    // 플레이어 유닛 배치
    [SerializeField] float _unitSetPositionZ;
    public float UnitSetPositionZ { get { return _unitSetPositionZ; } set { _unitSetPositionZ = value; } }


    //[SerializeField] Animator _animator;
    //public Animator Unit_Animator { get { return _animator; } set { _animator = value; } }

    public override void Set_UnitData(STO_UnitBase STO_Unit)
    {
        base.Set_UnitData(STO_Unit);
        STO_PlayerUnit STO_Player = STO_Unit as STO_PlayerUnit;
    }
}
