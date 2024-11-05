using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ReviveZombie : MonoBehaviour, ISendToPool
{
    ObjPool zombiePool;
    [SerializeField]
    GameObject zombiePrefab;

    private void Start()
    {
        zombiePool = new ObjPool();
        for (int i = 0; i < 5; i++)
        {
            zombiePool.PutInPool(Instantiate(zombiePrefab));
        }
        StartCoroutine(SpawnZombiesAtStart());
    }

    List<GameObject> takenZom = new List<GameObject>();
    Vector3 delta;
    int i = -2;
    IEnumerator SpawnZombiesAtStart()
    {
        while(true)
        {
            yield return new WaitForSeconds(1.5f);
            GameObject obj = zombiePool.TakeFromPool();
            if (obj != null)
            {
                takenZom.Add(obj);
                if (i == 3) i = -2;
                delta = Vector3.right * i * 4.5f;
                obj.transform.position += delta;
                i++;
            }
        }
    }

    public void SendToPool(GameObject objSent)
    {
        zombiePool.PutInPool(objSent);
    }

    void OnDestroy()
    {
        foreach (GameObject obj in takenZom)
        {
            Destroy(obj);
        }
        takenZom.Clear();
        zombiePool.DestroyPool();
    }
}
