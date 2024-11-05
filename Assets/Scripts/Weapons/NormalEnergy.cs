using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnergy : MonoBehaviour
{
    ObjPool normalEnergyPool;
    [SerializeField]
    GameObject normalEnergyPrefab;

    private void Start()
    {
        normalEnergyPool = new ObjPool();
        for (int i = 0; i < 15; i++)
        {
            normalEnergyPool.PutInPool(Instantiate(normalEnergyPrefab));
        }
        StartCoroutine(SpawnNormalEnergy());
        StartCoroutine(DisappearNormalEnergy());
    }

    List<GameObject> gObjs = new List<GameObject>();

    IEnumerator SpawnNormalEnergy()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));
            GameObject obj = normalEnergyPool.TakeFromPool();
            if (obj != null)
            {
                gObjs.Add(obj);
                obj.transform.position = new Vector3(Random.Range(-17f, 17f), 42, Random.Range(-55f, -20f));
            }
        }
    }
    IEnumerator DisappearNormalEnergy()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3, 15));
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
    }
}
