using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D.IK;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static GameMode_Manager;

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

    public Battle_State Turn_State;
    public bool isLive = false; // 생존 여부
    public int Turn_Count = 0; // 턴 카운트
    //private bool isTurn = false;

    IEnumerator C_Enemy_Turn;
    IEnumerator C_Player_Turn;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void Battle_Awake()
    {
        // 게임 시작시 배틀 시작이라고 타이틀 띄우는거 가능
        Turn_State = Battle_State.START; // 전투 시작 알림
        Battle_Start();
    }

    void Battle_Start()
    {
        // 전투 시작시 캐릭터 등장 애니메이션 효과 넣기
        StartCoroutine(Turn_Based_Battle());
    }

    IEnumerator Turn_Based_Battle()
    {
        while (isLive)
        {
            switch (Turn_State)
            {
                case Battle_State.IDLE:
                    break;
                case Battle_State.START:
                    Faster_Turn(); // 가장 빠른 유닛을 가지고 있는 쪽이 선공
                    break;
                case Battle_State.PLAYER_TURN:
                    yield return StartCoroutine(Player_Turn());
                    break;
                case Battle_State.ENEMY_TURN:
                    yield return StartCoroutine(Enemy_Turn());
                    break;
                case Battle_State.WIN:
                    Battle_End();
                    break;
                case Battle_State.LOST:
                    Battle_End();
                    break;
            }
            //yield return null;
        }
    }

    void Battle_End()
    {
        Debug.Log("전투 종료");
    }

    IEnumerator Player_Turn()
    {
        yield return new WaitUntil(() => Turn_End() == true);

        Debug.Log("플레이어 턴 끝");

        //yield return new WaitForSeconds(1.0f);

        // 적 죽었으면 전투 종료
        if (isLive == false)
        {
            Turn_State = Battle_State.WIN;
        }
        else
        {
            Turn_State = Battle_State.ENEMY_TURN;
            Turn_Count = 0;
        }
    }

    IEnumerator Enemy_Turn()
    {
        if (Turn_State == Battle_State.ENEMY_TURN)
        {
            Debug.Log("적 턴 시작");

            for (int i = 0; i < Enemy_List.Count; i++)
            {
                if (!Enemy_List[i].Is_Dead)
                {
                    // 적 유닛이 살아있으면 공격 수행
                    Unit_Base target = Get_Random_Player_Unit();
                    if (target != null)
                    {
                        Enemy_List[i].unitTarget = target;

                        // 적의 행동 선택 및 수행
                        int act = Enemy_List[i].Act.Length;
                        int Temp_Enemy_Act = Random.Range(0, act);
                        Enemy_List[i].Perform_Action(Enemy_List[i], target, Enemy_List[i].Act[Temp_Enemy_Act]);

                        // 행동 수행 중 대기
                        yield return new WaitForSeconds(1.0f);
                    }
                }
            }

            yield return new WaitUntil(() => Turn_End());

            // 모든 적 유닛의 행동이 끝났으면 턴을 플레이어 턴으로 전환
            Turn_State = Battle_State.PLAYER_TURN;
            Turn_Count = 0;
            yield return null;
        }
    }

    public void Enemy_AI()
    {

    }

    public bool Turn_End()
    {
        switch (Turn_State)
        {
            case Battle_State.PLAYER_TURN:
                if (Turn_Count >= Player_List.Count)
                {
                    return true;
                }
                break;
            case Battle_State.ENEMY_TURN:
                if (Turn_Count >= Enemy_List.Count)
                {
                    return true;
                }
                break;
        }
        return false;
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
        else if (Get_Object_Value(Faster_Player) < Get_Object_Value(Faster_Enemy))
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

    Unit_Base Get_Random_Player_Unit()
    {
        List<Unit_Base> alivePlayers = Player_List.FindAll(unit => !unit.Is_Dead);
        if (alivePlayers.Count > 0)
        {
            return alivePlayers[Random.Range(0, alivePlayers.Count)];
        }
        return null;
    }

    // 오브젝트에서 특정 값(예: CompareValue)을 가져오는 함수
    int Get_Object_Value(Unit_Base obj)
    {
        // 여기서는 CompareValue가 있는 컴포넌트에서 값을 가져오는 것으로 가정합니다.
        // 실제 프로젝트에서는 이 부분을 수정하여 오브젝트에서 가져올 값을 결정하세요.
        return obj.GetComponent<Unit_Base>().UnitBase_Stat.unitSpeed;
    }

}
