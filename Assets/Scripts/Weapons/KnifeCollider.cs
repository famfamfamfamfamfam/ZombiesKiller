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
            ToCollectTheKnife();
        }
        else if (CommunicateManager.instance.MayBePlayingThing().IsPlaying() && theHilt.parent == playerRightHand && GameManager.instance.weaponAmount > 0)
        {
            CommunicateManager.instance.CanReactThing("Zombie")?.React();
            GameManager.instance.DecreaseValidDamage();
        }
    }

    void ToCollectTheKnife()
    {
        theHilt.position = playerRightHand.position;
        theHilt.SetParent(playerRightHand);
    }

    private void LateUpdate()
    {
        HoldTheKnife();
    }

    void HoldTheKnife()
    {
        if (theHilt.parent == playerRightHand)
        {
            theHilt.forward = -playerRightHand.right;
        }
    }

    int index = 0;
    void SpecialSkill(bool turnOnCondition, Vector3[] targetsPos)
    {
        if (turnOnCondition)
        {
            if (theHilt.parent != null) theHilt.SetParent(null);
            if (index == targetsPos.Length)
            {
                index = 0;
                return;
            }
            ResetForSpecialSkill(targetsPos[index]);
            theHilt.position = Vector3.MoveTowards(theHilt.position, targetsPos[index], 20 * Time.deltaTime);
            transform.rotation *= Quaternion.Euler(0, 720 * 3 * Time.deltaTime, 0);
            if (Vector3.Dot(theHilt.forward, targetsPos[index] - theHilt.position) <= 0)
            {
                index++;
                aTrigger = true;
            }
        }

    }
    bool aTrigger = true;
    void ResetForSpecialSkill(Vector3 target)
    {
        if (aTrigger)
        {
            if (index == 0) theHilt.position += Vector3.up * 5;
            theHilt.rotation = Quaternion.LookRotation(target - theHilt.position);
        }
        aTrigger = false;
    }
}
