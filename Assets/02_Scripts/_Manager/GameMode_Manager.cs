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
        StartCoroutine(Turn_Based_Battle());
    }

    // 전투 종료
    public void Battle_End()
    {
        Debug.Log("전투 종료 확인");
        All_Manager.instance.Setting_M.Stage_In = false;
    }

    IEnumerator Turn_Based_Battle()
    {
        // 처음 턴: 가장 빠른 유닛 찾기
        Unit_Base Faster_Unit = null;
        int HighSpeed = int.MinValue;

        // 속도가 높은 유닛 찾기 (Player List)
        for (int i = 0; i < Player_List.Count; i++)
        {
            if (Player_List[i] == null) continue;

            if (Player_List[i].UnitBase_Stat.unitSpeed > HighSpeed)
            {
                HighSpeed = Player_List[i].UnitBase_Stat.unitSpeed;
                Faster_Unit = Player_List[i];
            }
        }

        // 속도가 높은 유닛 찾기 (Enemy List)
        for (int i = 0; i < Enemy_List.Count; i++)
        {
            if (Enemy_List[i] == null) continue;

            if (Enemy_List[i].UnitBase_Stat.unitSpeed > HighSpeed)
            {
                HighSpeed = Enemy_List[i].UnitBase_Stat.unitSpeed;
                Faster_Unit = Enemy_List[i];
            }
        }

        // 첫 번째 턴: 가장 빠른 유닛이 Player 리스트에 있으면 Player 턴, Enemy 리스트에 있으면 Enemy 턴
        if (Player_List.Contains(Faster_Unit))
        {
            yield return StartCoroutine(Player_Turn());
        }
        else if (Enemy_List.Contains(Faster_Unit))
        {
            yield return StartCoroutine(Enemy_Turn());
        }

        // 그 이후 턴: 번갈아 가며 진행
        bool isPlayerTurn = Player_List.Contains(Faster_Unit); // 첫 턴이 플레이어 턴인지 여부
        int Turn_Count = 0;

        while (true)
        {
            // 현재 턴에 행동할 유닛 리스트
            List<Unit_Base> currentTurnList = isPlayerTurn ? Player_List : Enemy_List;

            // 턴 카운터 초기화
            Turn_Count = 0;

            // 현재 팀의 유닛들이 전부 행동할 때까지 턴 진행
            for (int i = 0; i < currentTurnList.Count; i++)
            {
                Unit_Base currentUnit = currentTurnList[i];

                if (currentUnit != null)
                {
                    // 유닛의 행동 처리
                    if (isPlayerTurn)
                    {
                        yield return StartCoroutine(Player_Turn()); // 플레이어 유닛의 행동
                    }
                    else
                    {
                        yield return StartCoroutine(Enemy_Turn()); // 적 유닛의 행동
                    }

                    // 턴 카운터 증가
                    Turn_Count++;

                    // 모든 유닛이 행동을 완료했는지 확인
                    if (Turn_Count >= currentTurnList.Count)
                    {
                        break; // 현재 턴 종료
                    }
                }
            }

            // 턴 교대
            isPlayerTurn = !isPlayerTurn;

            // 게임 종료 여부 체크 (필요한 경우 추가)
            if (isLive == false) break;
        }
    }


    // 플레이어 턴
    IEnumerator Player_Turn()
    {
        isProcessingTurn = true; // 턴이 진행 중임을 표시
        battleState = Battle_State.PLAYER_TURN;
        Debug.Log("플레이어 턴 확인");
        yield return new WaitForSeconds(1f);
    }

    // 에너미 턴
    IEnumerator Enemy_Turn()
    {
        isProcessingTurn = true; // 턴이 진행 중임을 표시
        battleState = Battle_State.ENEMY_TURN;
        Debug.Log("에너미 턴 확인");
        yield return new WaitForSeconds(1f);

        Enemy_Attack();
    }

    public void On_Attack_Button()
    {
        // 플레이어의 턴이 아니거나 이미 턴 진행 중이면 공격 불가
        if (battleState != Battle_State.PLAYER_TURN || isProcessingTurn) return;

        //isProcessingTurn = true; // 턴이 진행 중임을 표시
        All_Manager.instance.UI_M.Unit_Selector_Arrow.Current_Unit.Player_Unit_Attack();

        isProcessingTurn = false; // 턴이 끝남을 표시
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
        Debug.Log("에너미 공격");
        //Debug.Log("에너미 공격!" + Enemy_List[0].UnitBase_Stat.attackPower);
        //Debug.Log("플레이어 맞음!" + (Player_List[0].Current_HP - Enemy_List[0].UnitBase_Stat.attackPower));
        isProcessingTurn = false; // 턴이 끝남을 표시
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
        battleState = Battle_State.WIN;
        // 승리 처리
    }

    void Player_Lost()
    {
        battleState = Battle_State.LOST;
        // 패배 처리
    }
}