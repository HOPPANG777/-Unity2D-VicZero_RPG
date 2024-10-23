using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D.IK;
using UnityEngine.UI;

public class GameMode_Manager : MonoBehaviour
{
    public List<Unit_Base> Player_List = new List<Unit_Base>();
    public List<Unit_Base> Enemy_List = new List<Unit_Base>();
    //public List<Unit_Base> All_Units = new List<Unit_Base>();

    // 턴 상태 관리
    public enum Battle_State
    {
        IDLE,
        START,
        PLAYER_TURN,
        EXECUTE_ACTIONS,
        ENEMY_TURN,
        WIN,
        LOST
    }

    public Battle_State Turn_State;
    public bool isLive = true;

    private bool is_Processing_Turn = false; // 현재 턴이 진행 중인지 여부

    // 전투 시작 알림
    public void Battle_Awake()
    {
        // 전투 시작시 타이틀 띄워서 전투 시작 알림 보낼 수 있음
        Turn_State = Battle_State.START;
        Battle_Start();
    }

    // 전투 시작
    public void Battle_Start()
    {
        Turn_Base_Battle();
    }

    void Turn_Base_Battle()
    {
        StartCoroutine(C_Turn_Base_Battle());
    }

    void Player_Turn()
    {
        StartCoroutine(C_Player_Turn());
    }

    void Enemy_Turn()
    {
        StartCoroutine(C_Enemy_Turn());
    }

    void Execute_Act()
    {
        StartCoroutine(C_Execute_Act());
    }

    public void Lost_or_Win()
    {
        bool allPlayersDead = true;
        for (int i = 0; i < Player_List.Count; i++)
        {
            if (Player_List[i].Is_Dead == true)
            {
                allPlayersDead = false;
                break;
            }
        }

        bool allEnemiesDead = true;
        for (int i = 0; i < Enemy_List.Count; i++)
        {
            if (!Enemy_List[i].Is_Dead == true)
            {
                allEnemiesDead = false;
                break;
            }
        }

        if (allPlayersDead)
        {
            isLive = false;
            Player_Lost();
        }

        if (allEnemiesDead)
        {
            isLive = false;
            Player_Win();
        }
    }

    void Player_Lost()
    {
        Turn_State = Battle_State.LOST;
        Debug.Log("플레이어 패배 확인");
    }

    void Player_Win()
    {
        Turn_State = Battle_State.WIN;
        Debug.Log("플레이어 승리 확인");
    }


    public void Battle_End()
    {
        Debug.Log("전투 종료");
    }

    IEnumerator C_Turn_Base_Battle()
    {

        while (isLive == true)
        {
            switch (Turn_State)
            {
                case Battle_State.START:
                    // 전투 시작시 초기화
                    yield return new WaitForSeconds(1.0f); 
                    Faster_Turn();
                    break;
                case Battle_State.PLAYER_TURN:
                    Player_Turn();
                    break;
                case Battle_State.EXECUTE_ACTIONS:
                    Execute_Act();
                    break;
                case Battle_State.ENEMY_TURN:
                    Enemy_Turn();
                    break;
                case Battle_State.WIN:
                    Battle_End();
                    break;
                case Battle_State.LOST:
                    Battle_End();
                    break;
            }
        }

    }

    IEnumerator C_Player_Turn()
    {
        Debug.Log("플레이어 턴 시작");

        // 플레이어의 각 유닛이 행동을 결정할 때까지 기다림
        foreach (var playerUnit in Player_List)
        {
            if (playerUnit.Is_Dead) continue;

            // 여기서 플레이어의 입력을 기다리며, 행동을 결정
            All_Manager.instance.UI_M.Unit_Selector_Arrow.Wait_For_Player_Input();

            // 플레이어 행동이 결정되면 타겟 확인
            if (playerUnit.unitTarget == null || playerUnit.unitTarget.Is_Dead)
            {
                playerUnit.unitTarget = Enemy_List.Find(enemy => !enemy.Is_Dead);
                if (playerUnit.unitTarget == null) yield break; // 더 이상 타겟이 없으면 종료
            }
        }

        Turn_State = Battle_State.EXECUTE_ACTIONS;
    }

    IEnumerator C_Enemy_Turn()
    {
        Debug.Log("적 턴 시작");

        foreach (var enemyUnit in Enemy_List)
        {
            if (enemyUnit.Is_Dead) continue;

            // 타겟 결정
            if (enemyUnit.unitTarget == null || enemyUnit.unitTarget.Is_Dead)
            {
                enemyUnit.unitTarget = Player_List.Find(player => !player.Is_Dead);
                if (enemyUnit.unitTarget == null) yield break; // 더 이상 타겟이 없으면 종료
            }

            // 행동 수행
            yield return StartCoroutine(enemyUnit.Perform_Action());
        }

        // 플레이어 턴으로 전환
        Turn_State = Battle_State.PLAYER_TURN;
    }

    IEnumerator C_Execute_Act()
    {
        Debug.Log("행동 실행");

        // 모든 유닛이 행동을 수행함
        foreach (var unit in Player_List)
        {
            if (unit.Is_Dead) continue;

            // 행동 수행
            yield return StartCoroutine(unit.Perform_Action());

            // 타겟이 죽었는지 확인 후 재할당
            if (unit.unitTarget != null && unit.unitTarget.Is_Dead)
            {
                unit.unitTarget = unit.TeamType == TeamType.ALLY ?
                    Enemy_List.Find(enemy => !enemy.Is_Dead) :
                    Player_List.Find(player => !player.Is_Dead);

                if (unit.unitTarget == null) yield break; // 더 이상 타겟이 없으면 종료
            }
        }

        // 적의 턴으로 전환
        Turn_State = Battle_State.ENEMY_TURN;
    }

    void Faster_Turn()
    {
        // 두 리스트에서 각각 가장 큰 값을 가진 오브젝트를 찾습니다.
        Unit_Base Faster_Player = Find_Faster_Unit(Player_List);
        Unit_Base Faster_Enemy = Find_Faster_Unit(Enemy_List);

        // 두 값을 비교하여 더 큰 값을 가진 리스트를 찾습니다.
        if (Get_Object_Value(Faster_Player) > Get_Object_Value(Faster_Enemy))
        {
            Turn_State = Battle_State.PLAYER_TURN;
        }
        else if (Get_Object_Value(Faster_Player) > Get_Object_Value(Faster_Enemy))
        {
            Turn_State = Battle_State.ENEMY_TURN;
        }
    }

    // 리스트에서 가장 큰 값을 가진 오브젝트를 찾는 함수
    Unit_Base Find_Faster_Unit(List<Unit_Base> objects)
    {
        Unit_Base largestObject = objects[0];
        int largestValue = Get_Object_Value(largestObject);

        for (int i = 1; i < objects.Count; i++)
        {
            int currentValue = Get_Object_Value(objects[i]);
            if (currentValue > largestValue)
            {
                largestValue = currentValue;
                largestObject = objects[i];
            }
        }

        return largestObject;
    }

    // 오브젝트에서 특정 값(예: CompareValue)을 가져오는 함수
    int Get_Object_Value(Unit_Base obj)
    {
        // 여기서는 CompareValue가 있는 컴포넌트에서 값을 가져오는 것으로 가정합니다.
        // 실제 프로젝트에서는 이 부분을 수정하여 오브젝트에서 가져올 값을 결정하세요.
        return obj.GetComponent<Unit_Base>().UnitBase_Stat.unitSpeed;
    }

}
