using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeCollider : MonoBehaviour
{
    [SerializeField]
    Transform theHilt, playerRightHand;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            theHilt.position = playerRightHand.position;
            theHilt.SetParent(playerRightHand);
        }
        else if (other.gameObject.CompareTag("Zombie"))
        {
            Debug.Log("Omaewamoushindeiru");
        }
    }
    private void LateUpdate()
    {
        if (theHilt.parent == playerRightHand)
        {
            theHilt.forward = -playerRightHand.right;
        }
    }
}
