using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnMethods : MonoBehaviour
{
    protected IEnumerator Spawn(float timeToWait, ObjPool pool, List<GameObject> takenList, Action SetPosition)
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(timeToWait);
            GameObject obj = pool.TakeFromPool();
            if (obj != null)
            {
                takenList.Add(obj);
                SetPosition?.Invoke();
            }
        }
    }

    protected IEnumerator Spawn(float timeToWait, ObjPool pool, GameObject takenObj, Func<IEnumerator> SetPosAndWait)
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToWait);
            takenObj = pool.TakeFromPool();
            SetPosAndWait?.Invoke();
        }
    }

}
