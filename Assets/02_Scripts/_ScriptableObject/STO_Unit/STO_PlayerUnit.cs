using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "UnitData/PlayerData", order = 1)]
public class STO_PlayerUnit : STO_UnitBase
{
    //[Header("STO_PlayerUnit")]
    // 플레이어 레벨
    // 스킬추가 해야함


    public override void Set_UnitData(STO_UnitBase STO_Unit)
    {
        base.Set_UnitData(STO_Unit);
        STO_PlayerUnit STO_Player = STO_Unit as STO_PlayerUnit;
    }
}
