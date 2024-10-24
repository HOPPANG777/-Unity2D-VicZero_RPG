using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D.IK;
using UnityEngine.UI;
using static GameMode_Manager;

public class GameMode_Manager : MonoBehaviour
{
    public List<Unit_Base> Player_List = new List<Unit_Base>();
    public List<Unit_Base> Enemy_List = new List<Unit_Base>();
    public List<Unit_Base> All_Units = new List<Unit_Base>();

    // 턴 상태 관리
    public enum Battle_State
    {
        IDLE,
        START,
        PLAYER_TURN,
        EXECUTE_TURN,
        ENEMY_TURN,
        WIN,
        LOST
    }

    public Battle_State Turn_State;
    public bool isLive = false; // 생존 여부
    public int Turn_Count = 0; // 턴 카운트
                               //private bool isTurn = false;


    private void Update()
    {

        // 행동이 가능한 유닛 확인
        foreach (Unit_Base unit in Player_List)
        {
            if (unit.isReadyToAct)
            {
                // 플레이어 행동 결정 로직
                //unit.Perform_Action();
            }
        }

        foreach (Unit_Base unit in Enemy_List)
        {
            EnemyTurn(unit);
        }

    }



    void EnemyTurn(Unit_Base enemyUnit)
    {
        if (enemyUnit.isReadyToAct)
        {
            // 행동할 타겟 결정 (랜덤 혹은 조건 기반)
            Unit_Base target = Get_Random_Player_Unit();
            int act = enemyUnit.Act.Length;
            int Temp_Enemy_Act = Random.Range(0, act);
            enemyUnit.Perform_Action(enemyUnit, target, enemyUnit.Act[Temp_Enemy_Act]); // 공격이나 스킬 수행
        }
    }


    private bool Turn_End()
    {
        switch (Turn_State)
        {
            case Battle_State.PLAYER_TURN:
                if (Turn_Count >= Player_List.Count + 1)
                {
                    return true;
                }
                break;
            case Battle_State.ENEMY_TURN:
                if (Turn_Count >= Enemy_List.Count + 1)
                {
                    return true;
                }
                break;
        }
        return false;
    }

    //void Faster_Turn()
    //{
    //    // 두 리스트에서 각각 가장 큰 값을 가진 오브젝트를 찾습니다.
    //    Unit_Base Faster_Player = Find_Faster_Unit(Player_List);
    //    Unit_Base Faster_Enemy = Find_Faster_Unit(Enemy_List);

    //    // 두 값을 비교하여 더 큰 값을 가진 리스트를 찾습니다.
    //    if (Get_Object_Value(Faster_Player) > Get_Object_Value(Faster_Enemy))
    //    {
    //        Turn_State = Battle_State.PLAYER_TURN;
    //    }
    //    else if (Get_Object_Value(Faster_Player) < Get_Object_Value(Faster_Enemy))
    //    {
    //        Turn_State = Battle_State.ENEMY_TURN;
    //    }
    //}



    Unit_Base Get_Random_Player_Unit()
    {
        List<Unit_Base> alivePlayers = Player_List.FindAll(unit => !unit.Is_Dead);
        if (alivePlayers.Count > 0)
        {
            return alivePlayers[Random.Range(0, alivePlayers.Count)];
        }
        return null;
    }
}
