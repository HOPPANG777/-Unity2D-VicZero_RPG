using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class GameMode_Manager : MonoBehaviour
{
    public List<Unit_Base> Player_List = new List<Unit_Base>();
    public List<Unit_Base> Enemy_List = new List<Unit_Base>();

    // 턴 상태 관리
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

    private bool isProcessingTurn = false; // 현재 턴이 진행 중인지 여부

    public void Start()
    {
        Battle_Awake();
    }

    // 전투 시작 알림
    public void Battle_Awake()
    {
        // 전투 시작시 타이틀 띄워서 전투 시작 알림 보낼 수 있음
        battleState = Battle_State.START;
        Battle_Start();
    }

    // 전투 시작
    public void Battle_Start()
    {
        //Debug.Log("전투시작");
        Unit_Base Faster_Unit = null;
        int HighSpeed = int.MinValue;

        // 속도가 높은 유닛 찾기
        foreach (var player in Player_List)
        {
            if (player == null) continue;

            if (player.UnitBase_Stat.unitSpeed > HighSpeed)
            {
                HighSpeed = player.UnitBase_Stat.unitSpeed;
                Faster_Unit = player;
            }
        }

        foreach (var enemy in Enemy_List)
        {
            if (enemy == null) continue;

            if (enemy.UnitBase_Stat.unitSpeed > HighSpeed)
            {
                HighSpeed = enemy.UnitBase_Stat.unitSpeed;
                Faster_Unit = enemy;
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
        isProcessingTurn = true; // 턴이 진행 중임을 표시
        battleState = Battle_State.PLAYER_TURN;
        //Debug.Log("플레이어 턴 확인");
        yield return new WaitForSeconds(1f);
        isProcessingTurn = false; // 턴이 끝남을 표시
        All_Manager.instance.UI_M.Unit_Selector_Arrow.Current_Unit.Set_Unit_Position();
    }

    // 에너미 턴
    IEnumerator Enemy_Turn()
    {
        isProcessingTurn = true; // 턴이 진행 중임을 표시
        battleState = Battle_State.ENEMY_TURN;
        //Debug.Log("에너미 턴 확인");
        yield return new WaitForSeconds(1f);

        Enemy_Attack();
        isProcessingTurn = false; // 턴이 끝남을 표시
    }

    public void On_Attack_Button()
    {
        // 플레이어의 턴이 아니거나 이미 턴 진행 중이면 공격 불가
        if (battleState != Battle_State.PLAYER_TURN || isProcessingTurn) return;

        isProcessingTurn = true; // 턴이 진행 중임을 표시
        All_Manager.instance.UI_M.Unit_Selector_Arrow.Current_Unit.Player_Unit_Attack();

        StartCoroutine(Enemy_Turn());
    }

    public void On_Skill_Button()
    {
        // 스킬 버튼 로직 추가 가능
    }

    public void On_Defense_Button()
    {
        // 방어 버튼 로직 추가 가능
    }

    public void Enemy_Attack()
    {
        // 적의 공격 로직
        //Debug.Log("에너미 공격!" + Enemy_List[0].UnitBase_Stat.attackPower);
        //Debug.Log("플레이어 맞음!" + (Player_List[0].Current_HP - Enemy_List[0].UnitBase_Stat.attackPower));
        StartCoroutine(Player_Turn());
    }

    public void Lost_or_Win()
    {
        foreach (var player in Player_List)
        {
            if (player.Is_Dead)
            {
                isLive = false;
                Player_Lost();
                Battle_End();
                return; // 패배 시 바로 종료
            }
        }

        foreach (var enemy in Enemy_List)
        {
            if (enemy.Is_Dead)
            {
                isLive = false;
                Player_Win();
                Battle_End();
                return; // 승리 시 바로 종료
            }
        }
    }

    void Player_Win()
    {
        battleState = Battle_State.WIN;
        // 승리 처리
    }

    void Player_Lost()
    {
        battleState = Battle_State.LOST;
        // 패배 처리
    }
}