using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 오브젝트에 해당 컴포넌트를 복수개 붙일 수 없게 하는 어트리뷰트
[DisallowMultipleComponent]  // 중복 컴포넌트 추가 방지
public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T Instance;
    private static bool isApplicationQuit = false;

    public static T instance
    {
        get
        {
            if (isApplicationQuit == true)
                return null;

            if (Instance == null)
            {
                T[] Find_Instance = FindObjectsOfType<T>();
                if (Find_Instance.Length > 0)
                {
                    Instance = Find_Instance[0];
                    DontDestroyOnLoad(Instance.gameObject);
                }

                if (Find_Instance.Length > 1)
                {
                    for (int i = 1; i < Find_Instance.Length; i++)
                        Destroy(Find_Instance[i].gameObject);
                }

                if (Instance == null)
                {
                    GameObject Create_GameObject = new GameObject(typeof(T).Name);
                    DontDestroyOnLoad(Create_GameObject);
                    Instance = Create_GameObject.AddComponent<T>();
                }
            }
            return Instance;
        }
    }

    private void OnApplicationQuit()
    {
        isApplicationQuit = true;
    }

}