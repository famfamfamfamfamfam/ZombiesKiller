using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ReviveZombie : SpawnMethods, ISendToPool, IOrderOfRunningStart, IOnSpecialSkill
{
    ObjPool zombiePool;
    [SerializeField]
    GameObject zombiePrefab;

    public void Init()
    {
        zombiePool = new ObjPool();
        for (int i = 0; i < 5; i++)
        {
            zombiePool.PutInPool(Instantiate(zombiePrefab));
        }
        StartCoroutine(Spawn(1.5f, zombiePool, takenZom, ZomPos));
    }

    List<GameObject> takenZom = new List<GameObject>();
    Vector3 delta;
    int i = -2;
    void ZomPos()
    {
        if (i == 3) i = -2;
        delta = Vector3.right * i * 4.5f;
        takenZom[takenZom.Count - 1].transform.position += delta;
        i++;
    }

    public void SendToPool(GameObject objSent)
    {
        zombiePool.PutInPool(objSent);
        takenZom.RemoveAt(0);
    }

    [SerializeField]
    Transform theWall;
    public void OnSpecialSkill()
    {
        for (int i = 0; i < takenZom.Count; i++)
        {
            if (!GameManager.instance.hasRunOnDestroy)
                takenZom[i].transform.SetParent(theWall);
            CommunicateManager.instance.SpecialSkill(takenZom[i])?.OnSpecialSkill();
        }
    }

    void OnDestroy()
    {
        foreach (GameObject obj in takenZom)
        {
            Destroy(obj);
        }
        takenZom.Clear();
        zombiePool.DestroyPool();
        StopAllCoroutines();
    }
}
