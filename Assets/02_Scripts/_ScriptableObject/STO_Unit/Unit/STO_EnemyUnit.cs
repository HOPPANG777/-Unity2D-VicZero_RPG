using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy_Base_Data", menuName = "Unit_Data/Enemy_Data", order = 1)]
public class STO_EnemyUnit : STO_UnitBase
{
    [Header("STO_EnemyUnit")]
    // 지급 경험치
    [SerializeField] protected int _rewardExp;
    public int RewardExp { get { return _rewardExp; } set { _rewardExp = value; } }

    // 에너미 유닛 배치
    [SerializeField] Vector3 _unitSetPosition;
    public Vector3 UnitSetPosition { get { return _unitSetPosition; } set { _unitSetPosition = value; } }

    // 에너미 유닛 플립
    [SerializeField] bool _unitSetFlipX = false;
    public bool UnitSetFlipX { get { return _unitSetFlipX; } set { _unitSetFlipX = value; } }


    public override void Set_UnitData(STO_UnitBase STO_Unit)
    {
        base.Set_UnitData(STO_Unit);
        STO_EnemyUnit STO_Enemy = STO_Unit as STO_EnemyUnit;

        this._rewardExp = STO_Enemy.RewardExp;
    }

}
