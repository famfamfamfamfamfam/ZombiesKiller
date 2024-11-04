using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovementOnSecondStage : MonoBehaviour
{
    [SerializeField]
    Transform player;

    private void Update()
    {
        CaculateDirToPlayer();
        SetTheAngles();
        SlerpTo();
    }

    Vector3 dirToPlayer;
    void CaculateDirToPlayer()
    {
        dirToPlayer = player.position - transform.position;
    }

    Quaternion theOldAngle, theTargetAngle;
    void SetTheAngles()
    {
        if (timeElapse == 0)
        {
            theOldAngle = transform.rotation;
        }
        theTargetAngle = Quaternion.LookRotation(dirToPlayer);
    }

    float timeElapse;
    void SlerpTo()
    {
        timeElapse += Time.deltaTime;
        if (timeElapse > 1)
        {
            timeElapse = 0;
            return;
        }
        transform.rotation = Quaternion.Slerp(theOldAngle, theTargetAngle, timeElapse);
    }
}
