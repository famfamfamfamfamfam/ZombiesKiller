using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForPrefabs : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Special"))
        {
            GameManager.instance.SetSpecialEnergy();
        }
        else
        {
            GameManager.instance.AddValidDamage();
        }

        gameObject.SetActive(false);
    }
}
