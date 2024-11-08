using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeCollider : MonoBehaviour, IOnSpecialSkill, IAdjustTransform
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
    void SpecialSkill(Vector3[] targetsPos)
    {
        if (theHilt.parent != null) theHilt.SetParent(null);
        if (index == targetsPos.Length)
        {
            index = 0;
            return;
        }
        ResetForSpecialSkill(targetsPos[index]);
        theHilt.position = Vector3.MoveTowards(theHilt.position, targetsPos[index], 20 * Time.deltaTime);
        transform.rotation *= Quaternion.Euler(0, 540 * 3 * Time.deltaTime, 0);
        if (Vector3.Dot(theHilt.forward, targetsPos[index] - theHilt.position) <= 0)
        {
            index++;
            aTrigger = true;
            CommunicateManager.instance.SpecialSkill("Zombie2")?.OnSpecialSkill();
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

    [SerializeField]
    Transform zom;

    Vector3[] movePos = new Vector3[2];

    public void OnSpecialSkill()
    {
        movePos[0] = zom.position + Vector3.up * 2 + Vector3.right * 2;
        movePos[1] = zom.position + Vector3.up * 2 - Vector3.right * 2;
        SpecialSkill(movePos);
    }
    public void AdjustTransform()
    {
        AdjustRotationOfTheKnife();
    }


    void AdjustRotationOfTheKnife()
    {
        transform.forward = theHilt.forward;
    }
}
