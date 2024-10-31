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
        SetTheAngles(dirToPlayer);
        SlerpTo();
    }

    Vector3 dirToPlayer;
    void CaculateDirToPlayer()
    {
        dirToPlayer = player.position - transform.position;
    }

    Quaternion theOldAngle, theTargetAngle;
    public void SetTheAngles(Vector3 dir)
    {
        if (timeElapse == 0)
        {
            theOldAngle = transform.rotation;
        }
        theTargetAngle = Quaternion.LookRotation(dir);
    }

    float timeElapse;
    public void SlerpTo()
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
