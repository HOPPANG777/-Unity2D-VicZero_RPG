using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource_Manager : MonoBehaviour
{
    [Header("Player_Unit")]
    // 플레이어 유닛 ScriptableObject
    public STO_PlayerUnit[] STO_PlayerUnits;

    [Header("Enemy_Unit")]
    // 에너미 유닛 ScriptableObject
    public STO_EnemyUnit[] STO_EnemyUnits;

    [Header("Prefabs")]
    // 프리팹
    public GameObject UI_Arrow_Prefab;
    public List<GameObject> Unit_Prefab_List = new List<GameObject>();

    [Header("Misc")]
    // 기타
    public List<Vector3> Player_Unit_Set_Position = new List<Vector3>();

    [Header("System")]
    // 시스템
    public Stage_Controller Stage_Ctrl;

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    // 이름을 플레이어 유닛으로 컨버트
    public STO_PlayerUnit Convert_Name_To_PlayerSTO(string name)
    {
        STO_PlayerUnit TempPlayerData = null;

        for (int i = 0; i < STO_PlayerUnits.Length; i++)
        {
            if (STO_PlayerUnits[i].Unit_Name == name) TempPlayerData = STO_PlayerUnits[i];
        }

        return TempPlayerData;
    }

    // 이름을 에너미 유닛으로 컨버트
    public STO_EnemyUnit Convert_Name_To_EnemySTO(string name)
    {
        STO_EnemyUnit TempEnemyData = null;

        for (int i = 0; i < STO_EnemyUnits.Length; i++)
        {
            if (STO_EnemyUnits[i].Unit_Name == name) TempEnemyData = STO_EnemyUnits[i];
        }

        return TempEnemyData;
    }

    //public Unit_Base Convert_Name_And_Team_To_Unit(string name, )

    public STO_Base_Act Convert_Name_To_Act(string name, Unit_Base Unit)
    {
        STO_Base_Act TempActData = null;

        for (int i = 0; i < Unit.Act.Length; i++)
        {
            if (Unit.Act[i].Act_Name == name) TempActData = Unit.Act[i];
        }

        return TempActData;
    }

}
