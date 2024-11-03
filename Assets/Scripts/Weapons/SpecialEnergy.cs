using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEnergy : MonoBehaviour
{
    ObjPool specialEnergyPool = new ObjPool();
    [SerializeField]
    GameObject specialEnergyPrefab;

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            specialEnergyPool.PutInPool(Instantiate(specialEnergyPrefab));
        }
        StartCoroutine(SpawnSpecialEnergy(0));
        StartCoroutine(SpawnSpecialEnergy(1));
    }

    GameObject[] gObj = new GameObject[2];
    IEnumerator SpawnSpecialEnergy(int index)
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 20));
            gObj[index] = specialEnergyPool.TakeFromPool();
            gObj[index].SetActive(true);
            gObj[index].transform.position = new Vector3(Random.Range(-17f, 17f), 42, Random.Range(-55f, -20f));
            yield return StartCoroutine(DisappearSpecialEnergy(index));
        }
    }
    IEnumerator DisappearSpecialEnergy(int index)
    {
        yield return new WaitForSeconds(Random.Range(5, 10));
        gObj[index].SetActive(false);
        specialEnergyPool.PutInPool(gObj[index]);
    }
}
