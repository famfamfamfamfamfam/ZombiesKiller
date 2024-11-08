using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnergy : SpawnMethods, IOrderOfRunningStart
{
    ObjPool normalEnergyPool;
    [SerializeField]
    GameObject normalEnergyPrefab;

    public void Init()
    {
        normalEnergyPool = new ObjPool();
        for (int i = 0; i < 15; i++)
        {
            normalEnergyPool.PutInPool(Instantiate(normalEnergyPrefab));
        }
        StartCoroutine(Spawn(UnityEngine.Random.Range(1, 5), normalEnergyPool, gObjs, NormalEnergyPos));
        StartCoroutine(DisappearNormalEnergy());
    }

    List<GameObject> gObjs = new List<GameObject>();

    void NormalEnergyPos()
    {
        gObjs[gObjs.Count - 1].transform.position = new Vector3(UnityEngine.Random.Range(-17f, 17f), 42, UnityEngine.Random.Range(-55f, -20f));
    }

    IEnumerator DisappearNormalEnergy()
    {
        while (true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(3, 15));
            if (gObjs.Count > 0 && gObjs[0] != null)
            {
                normalEnergyPool.PutInPool(gObjs[0]);
                gObjs.RemoveAt(0);
            }
        }
    }

    private void OnDestroy()
    {
        foreach (GameObject obj in gObjs)
        {
            Destroy(obj);
        }
        gObjs.Clear();
        normalEnergyPool.DestroyPool();
        StopAllCoroutines();
    }
}
