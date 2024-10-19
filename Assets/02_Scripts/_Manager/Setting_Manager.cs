using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//이거 이 타입 유니티에 연결시켜줘 나 하이라키에서 보게
//직렬화
[System.Serializable] // 게임 상태 : 인게임(타이틀 화면), 게임오버(사망), 게임 클리어(게임 클리어)
public enum Game_State
{
    IDLE,   // 기본상태 : 게임 실행 이전
    INGAME,
    GAMEOVER,
    GAMECLEAR,
    INTBATTLE
}

public class Setting_Manager : MonoBehaviour
{
    // 게임 기본상태
    public Game_State GM_State = Game_State.IDLE;

    //게임시간
    public float Game_Time = 0;

    // 게임 일시정지
    public bool Game_Stop = false;

    // 배틀 스테이지 진입
    public bool Stage_In = false;

    private void Update()
    {
        switch (GM_State)
        {
            case Game_State.IDLE:
                {

                }
                break;
            case Game_State.INGAME:
                {
                    if (Game_Stop == false)
                    {
                        Game_Time += Time.deltaTime;
                    }
                    else
                    {
                        
                    }
                }
                break;
            case Game_State.GAMEOVER:
                {
                    Game_Time = 0.0f;
                }
                break;
            case Game_State.GAMECLEAR:
                {
                    Game_Time = 0.0f;
                }
                break;
            case Game_State.INTBATTLE:
                {
                    if (Game_Stop == false)
                    {
                        Game_Time += Time.deltaTime;
                        if (!Stage_In)
                        {
                            All_Manager.instance.GameMode_M.Battle_Awake();
                            Stage_In = true;
                        }
                        else
                        {

                        }
                    }
                    else
                    {

                    }
                }
                break;
        }
    }

    // 게임 시작(타이틀 화면에서의 시작)
    public void Game_Start()
    {
        GM_State = Game_State.INGAME;
    }

    // 게임 종료
    public void Game_Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}
