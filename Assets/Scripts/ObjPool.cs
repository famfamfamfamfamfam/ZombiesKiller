using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPool
{
    List<GameObject> inPoolObjs;
    public ObjPool()
    {
        inPoolObjs = new List<GameObject>();
    }
    public void PutInPool(GameObject obj)
    {
        obj.SetActive(false);
        inPoolObjs.Add(obj);
    }
    public GameObject TakeFromPool()
    {
        if (inPoolObjs.Count > 0)
        {
            GameObject obj = inPoolObjs[0];
            inPoolObjs.RemoveAt(0);
            obj.SetActive(true);
            return obj;
        }
        return null;
    }

}
