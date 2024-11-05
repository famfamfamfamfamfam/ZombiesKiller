using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEnergy : MonoBehaviour
{
    ObjPool specialEnergyPool = new ObjPool();
    [SerializeField]
    GameObject specialEnergyPrefab;
    GameObject gObj;

    private void Start()
    {
        gObj = new GameObject();
        for (int i = 0; i < 3; i++)
        {
            specialEnergyPool.PutInPool(Instantiate(specialEnergyPrefab));
        }
        StartCoroutine(SpawnSpecialEnergy());
    }

    IEnumerator SpawnSpecialEnergy()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3, 20));
            gObj = specialEnergyPool.TakeFromPool();
            gObj.transform.position = new Vector3(Random.Range(-17f, 17f), 42, Random.Range(-55f, -20f));
            yield return StartCoroutine(DisappearSpecialEnergy());
        }
    }
    IEnumerator DisappearSpecialEnergy()
    {
        yield return new WaitForSeconds(Random.Range(5, 10));
        specialEnergyPool.PutInPool(gObj);
    }
}
