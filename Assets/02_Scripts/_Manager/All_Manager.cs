using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class All_Manager : Singleton<All_Manager>
{
    public Audio_Manager Audio_M;
    public GameMode_Manager GameMode_M;
    public Resource_Manager Resource_M;
    public Setting_Manager Setting_M;
    public Pool_Manager Pool_M;
    public UI_Manager UI_M;
    public CoroutineManager Coroutine_M;
    public Object_Pool Obj_Pool;
    public Scene_Handler Scene_H;
    public Player_Unit_Factory Player_Factory;
    public Enemy_Unit_Factory Enemy_Factory;

    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
        Application.targetFrameRate = 60;

        // 그냥 싱글톤 다 넣으면 안되냐 하는데 사실 유니티는 싱글톤의 자식 오브젝트들도 전부 싱글톤이 되어서 그냥 총괄 싱글톤 하나만 만들어 놓고 자식 오브젝트로 포함시키면 싱글톤을 하나만 써도 된다.
        if (UI_M == null) Debug.Log("UI_Manager 없음");
        if (Setting_M == null) Debug.Log("Setting_Manager 없음");
        if (GameMode_M == null) Debug.Log("GameMode_Manager 없음");
        if (Pool_M == null) Debug.Log("Pool_Manager 없음");
        if (Resource_M == null) Debug.Log("Resource_Manager 없음");
        if (Audio_M == null) Debug.Log("Audio_Manager 없음");
        if (Coroutine_M == null) Debug.Log("Coroutine_Manager 없음");
        if (Obj_Pool == null) Debug.Log("Object_Pool 없음");
        if (Scene_H == null) Debug.Log("Scene_Handler 없음");
        if (Player_Factory == null) Debug.Log("Player_Unit_Factory 없음");
        if (Enemy_Factory == null) Debug.Log("Enemy_Unit_Factory 없음");

        Setting_M.Game_Start();
    }

}
