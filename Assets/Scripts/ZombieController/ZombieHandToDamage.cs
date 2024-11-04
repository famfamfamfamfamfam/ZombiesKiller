using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHandToDamage : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Here Animate React of Character");
    }
}
