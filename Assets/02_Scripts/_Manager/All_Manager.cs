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

    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
        Application.targetFrameRate = 60;

        if (UI_M == null) Debug.Log("UI_Manager 없음");
        if (Setting_M == null) Debug.Log("Setting_Manager 없음");
        if (GameMode_M == null) Debug.Log("GameMode_Manager 없음");
        if (Pool_M == null) Debug.Log("Pool_Manager 없음");
        if (Resource_M == null) Debug.Log("Resource_Manager 없음");
        if (Audio_M == null) Debug.Log("Audio_Manager 없음");
        if (Coroutine_M == null) Debug.Log("Coroutine_Manager 없음");
        if (Obj_Pool == null) Debug.Log("Object_Pool 없음");

        Setting_M.Game_Start();
    }

}
