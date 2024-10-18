using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource_Manager : Singleton<Resource_Manager>
{
    // 플레이어 유닛 ScriptableObject
    public STO_PlayerUnit[] STO_PlayerUnits;

    // 에너미 유닛 ScriptableObject
    public STO_EnemyUnit[] STO_EnemyUnits;

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    // 이름을 플레이어 유닛으로 컨버트
    public STO_PlayerUnit ConvertNameToPlayerSTO(string name)
    {
        STO_PlayerUnit TempPlayerData = null;

        for (int i = 0; i < STO_PlayerUnits.Length; i++)
        {
            if (STO_PlayerUnits[i].UnitInfo.unitName == name) TempPlayerData = STO_PlayerUnits[i];
        }

        return TempPlayerData;
    }

    // 이름을 에너미 유닛으로 컨버트
    public STO_EnemyUnit ConvertNameToEnemySTO(string name)
    {
        STO_EnemyUnit TempEnemyData = null;

        for (int i = 0; i < STO_EnemyUnits.Length; i++)
        {
            if (STO_EnemyUnits[i].UnitInfo.unitName == name) TempEnemyData = STO_EnemyUnits[i];
        }

        return TempEnemyData;
    }

}
