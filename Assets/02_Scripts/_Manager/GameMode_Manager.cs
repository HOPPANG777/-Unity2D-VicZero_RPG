using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class GameMode_Manager : MonoBehaviour
{
    public List<Unit_Base> Player_List = new List<Unit_Base>(); 
    public List<Unit_Base> Enemy_List = new List<Unit_Base>(); 

    // 턴
    public enum Battle_State
    {
        IDLE,
        START,
        PLAYER_TURN,
        ENEMY_TURN,
        WIN,
        LOST
    }

    public Battle_State battleState;
    public bool isLive = true;

    //IEnumerator Temp_Coroutine;

    public void Start()
    {
        
    }

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
        Debug.Log("전투시작");
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

        if (Player_List.Contains(Faster_Unit)) StartCoroutine(Player_Turn());
        if (Enemy_List.Contains(Faster_Unit)) StartCoroutine(Enemy_Turn());
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
        battleState = Battle_State.PLAYER_TURN;
        Debug.Log("플레이어 턴 확인");
    }

    // 에너미 턴
    IEnumerator Enemy_Turn()
    {
        yield return new WaitForSeconds(1f);
        battleState = Battle_State.ENEMY_TURN;
        Debug.Log("에너미 턴 확인");

        Enemy_Attack();
    }

    public void On_Attack_Button()
    {
        if (battleState != Battle_State.PLAYER_TURN) return;
        Debug.Log("플레이어 공격!" + (Player_List[0].UnitBase_Stat.attackPower));
        Debug.Log("에너미 처맞음!" + (Enemy_List[0].Current_HP - Player_List[0].UnitBase_Stat.attackPower));

        StartCoroutine(Enemy_Turn());
    }

    public void On_Skill_Button()
    {

    }

    public void On_Defense_Button()
    {

    }

    public void Enemy_Attack()
    {
        Debug.Log("에너미 공격!" + Enemy_List[0].UnitBase_Stat.attackPower);
        Debug.Log("플레이어 맞음!" + (Player_List[0].Current_HP - Enemy_List[0].UnitBase_Stat.attackPower));
        StartCoroutine(Player_Turn());
    }

    public void Lost_or_Win()
    {
        for (int i = 0; i < Player_List.Count; i++)
        {
            if (Player_List[i].Is_Dead == true)
            {
                isLive = false;
                Player_Lost();
                Battle_End();
            }
        }

        for (int i = 0; i < Enemy_List.Count; i++)
        {
            if (Enemy_List[i].Is_Dead == true)
            {
                isLive = false;
                Player_Win();
                Battle_End();
            }
        }

    }

    void Player_Win()
    {
        // 여기에다가 이제 이겼다고 경험치 주는 거랑 타이틀 띄우는거 하면 될꺼같고
        battleState = Battle_State.WIN;

    }

    void Player_Lost()
    {
        // 졌으면 Lost 타이틀 띄우고 재시작 할꺼냐고 물어보면 된다.
        battleState = Battle_State.LOST;
    }

}
