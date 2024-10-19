using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyBaseData", menuName = "UnitData/EnemyBaseData", order = 1)]
public class STO_EnemyUnit : STO_UnitBase
{
    [Header("STO_EnemyUnit")]
    // 지급 경험치
    [SerializeField] protected int _rewardExp;
    public int RewardExp { get { return _rewardExp; } set { _rewardExp = value; } }

    [SerializeField] Animation_State _animState;
    public Animation_State Anim_State { get { return _animState; } set { _animState = value; } }

    public override void Set_UnitData(STO_UnitBase STO_Unit)
    {
        base.Set_UnitData(STO_Unit);
        STO_EnemyUnit STO_Enemy = STO_Unit as STO_EnemyUnit;

        this._rewardExp = STO_Enemy.RewardExp;
    }

}
