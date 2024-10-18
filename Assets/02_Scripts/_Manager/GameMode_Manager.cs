using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameMode_Manager : Singleton<GameMode_Manager>
{
    public List<Unit_Base> Player_List = new List<Unit_Base>(); 
    public List<Unit_Base> Enemy_List = new List<Unit_Base>(); 

    // 턴
    public enum Battle_State
    {
        START,
        PLAYER_TURN,
        ENEMY_TURN,
        WIN,
        LOST
    }

    public Battle_State battleState;
    public bool isLive;

    IEnumerator Temp_Coroutine;

    // 전투 시작 알림
    public void Battle_Awake()
    {
        // 여기에 전투 시작시 타이틀 띄워서 전투 시작 알림 보낼수도 있음
        battleState = Battle_State.START;
        Battle_Start();
    }

    // 전투 시작
    public void Battle_Start()
    {
        // 전투 시작시 캐릭터 등장 애니메이션 등 연출
        // 해당 시작은 유닛의 속도에 따라 플레이어 턴과 적의 턴이 정해져야 한다.
        // Debug.Log("전투시작");
        Unit_Base Faster_Unit = null;
        int HighSpeed = int.MinValue;

        for (int i = 0; i < Player_List.Count; i++)
        {
            if (Player_List[i] == null) return;

            if (Player_List[i].UnitBase_Stat.unitSpeed > HighSpeed)
            {
                HighSpeed = Player_List[i].UnitBase_Stat.unitSpeed;
                Faster_Unit = Player_List[i];
            }
        }

        for (int i = 0; i < Enemy_List.Count; i++)
        {
            if (Enemy_List[i] == null) return;

            if (Enemy_List[i].UnitBase_Stat.unitSpeed > HighSpeed)
            {
                HighSpeed = Enemy_List[i].UnitBase_Stat.unitSpeed;
                Faster_Unit = Enemy_List[i];
            }
        }

        if (Player_List.Contains(Faster_Unit)) All_Manager.instance.Coroutine_M.Start_Coroutine(Player_Turn());
        if (Enemy_List.Contains(Faster_Unit)) All_Manager.instance.Coroutine_M.Start_Coroutine(Enemy_Turn());
    }

    // 전투 종료
    public void Battle_End()
    {
        Debug.Log("전투 종료 확인");
    }

    // 플레이어 턴
    IEnumerator Player_Turn()
    {
        yield return new WaitForSeconds(1f);
        //Debug.Log("플레이어 턴 확인");
        battleState = Battle_State.PLAYER_TURN;



        // 해당 턴이 종료된뒤 에너미 턴으로 변경
        battleState = Battle_State.ENEMY_TURN;
    }

    // 에너미 턴
    IEnumerator Enemy_Turn()
    {
        yield return new WaitForSeconds(1f);
        //Debug.Log("에너미 턴 확인");
        battleState = Battle_State.ENEMY_TURN;



        // 해당 턴이 종료된뒤 플레이어 턴으로 변경
        battleState = Battle_State.PLAYER_TURN;
    }

}
