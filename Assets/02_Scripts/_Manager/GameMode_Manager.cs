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
    public bool isLive = true; // 생존 여부
    public int Turn_Count = 0; // 턴 카운트
    private bool isTurn = false;

    public void Battle_Awake()
    {
        // 게임 시작시 배틀 시작이라고 타이틀 띄우는거 가능
        Turn_State = Battle_State.START; // 전투 시작 알림
        Battle_Start();
    }

    void Battle_Start()
    {
        // 전투 시작시 캐릭터 등장 애니메이션 효과 넣기
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
                    StartCoroutine(Player_Turn());
                    break;
                case Battle_State.ENEMY_TURN:
                    StartCoroutine(Enemy_Turn());
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

    void Battle_End()
    {
        Debug.Log("전투 종료");
    }

    IEnumerator Player_Turn()
    {
        yield return new WaitUntil(() => Turn_End() == true);

        // 적 죽었으면 전투 종료
        if (!isLive)
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
        yield return new WaitUntil(() => Turn_End() == true);
        
        Turn_State = Battle_State.PLAYER_TURN;
        Turn_Count = 0;
    }

    public bool Turn_End()
    {
        switch (Turn_State)
        {
            case Battle_State.PLAYER_TURN:
                {
                    if (Turn_Count >= Player_List.Count)
                    {
                        isTurn = true;
                    }
                    else if (Turn_Count <= Player_List.Count)
                    {
                        isTurn = false;
                    }
                }
                break;
            case Battle_State.ENEMY_TURN:
                {
                    if (Turn_Count >= Enemy_List.Count)
                    {
                        isTurn = true;
                    }
                    else if (Turn_Count <= Enemy_List.Count)
                    {
                        isTurn = false;
                    }
                }
                break;
        }

        return isTurn;
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
