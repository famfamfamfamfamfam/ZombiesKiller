using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveZombie : MonoBehaviour
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

    Vector3 delta;
    int i = -2;
    IEnumerator SpawnZombiesAtStart()
    {
        for (int j = 0; j < 5; j++)
        {
            yield return new WaitForSeconds(1.5f);
            GameObject obj = zombiePool.TakeFromPool();
            if (obj != null)
            {
                if (i == 6) i = -2;
                delta = Vector3.right * i * 4.5f;
                obj.transform.position += delta;
                i++;
            }
        }
    }
}
