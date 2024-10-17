using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineManager : Singleton<CoroutineManager>
{
    public void Start_Coroutine(IEnumerator Coroutine, IEnumerator Temp_Coroutine)
    {
        Temp_Coroutine = Coroutine;

        StartCoroutine(Temp_Coroutine);
    }

    public IEnumerator Start_Run_Coroutine(IEnumerator Coroutine)
    {
        yield return StartCoroutine(Coroutine);
    }

    public void Stop_Runing_Coroutine(IEnumerator Coroutine)
    {
        StopCoroutine(Coroutine);
    }

}
