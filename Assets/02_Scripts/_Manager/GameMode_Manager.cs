using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class GameMode_Manager : Singleton<GameMode_Manager>
{
    // 턴
    public enum Turn_State
    {
        Battle_Start,
        Player_Turn,
        Enemy_Turn,
        Battle_Win,
        Battle_Defeat
    }

    public Turn_State turn;
    public bool isLive;

    IEnumerator Temp_Coroutine;

    // 전투 시작 알림
    public void Battle_Awake()
    {
        // 여기에 전투 시작시 타이틀 띄워서 전투 시작 알림 보낼수도 있음
        turn = Turn_State.Battle_Start;
        Battle_Start();
    }

    // 전투 시작
    public void Battle_Start()
    {
        // 전투 시작시 캐릭터 등장 애니메이션 등 연출
        // 해당 시작은 유닛의 속도에 따라 플레이어 턴과 적의 턴이 정해져야 한다.
        Debug.Log("전투시작");
        turn = Turn_State.Player_Turn;
    }

    //플레이어 공격
    public void Player_Attack_Button()
    {
        // 버튼이 계속 눌리는 것을 방지
        if (turn != Turn_State.Player_Turn)
        {
            return;
        }
        StartCoroutine(Player_Attack());
    }

    IEnumerator Player_Attack()
    {
        // 공격 스킬, 데미지 코드등 작성
        yield return new WaitForSeconds(1.0f);
        Debug.Log("플레이어 공격 활성화 확인");
        if (!isLive)
        {
            turn = Turn_State.Battle_Win;
            Battle_End();
        }
        else
        {
            turn = Turn_State.Enemy_Turn;
            StartCoroutine(Enemy_Turn());
        }

    }

    public void Battle_End()
    {
        Debug.Log("전투 종료 확인");
    }

    IEnumerator Enemy_Turn()
    {
        yield return new WaitForSeconds(1.0f);
        Debug.Log("적 공격 확인");
        turn = Turn_State.Enemy_Turn;
    }
}
