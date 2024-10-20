using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "UnitData/PlayerData", order = 1)]
public class STO_PlayerUnit : STO_UnitBase
{
    //[Header("STO_PlayerUnit")]
    // 플레이어 유닛 애니메이션 상태


    //[SerializeField] Animator _animator;
    //public Animator Unit_Animator { get { return _animator; } set { _animator = value; } }

    public override void Set_UnitData(STO_UnitBase STO_Unit)
    {
        base.Set_UnitData(STO_Unit);
        STO_PlayerUnit STO_Player = STO_Unit as STO_PlayerUnit;
    }
}
