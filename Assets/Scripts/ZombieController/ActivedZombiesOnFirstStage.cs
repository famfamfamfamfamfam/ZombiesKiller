using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivedZombiesOnFirstStage : MonoBehaviour, IDie
{
    Animator zombieController;

    private void OnEnable()
    {
        zombieController = GetComponent<Animator>();
        SetUpStartPositon();
    }

    void SetUpStartPositon()
    {
        transform.position = Vector3.up * 2.25f + Vector3.forward * 87.2f + Vector3.left * 2;
        transform.rotation = Quaternion.Euler(-90, 0, 0);
    }

    private void Update()
    {
        StopToClimb();
    }

    [SerializeField]
    Transform handReachingCrown, topWallCheckPoint;
    void StopToClimb()
    {
        if (handReachingCrown.position.y >= topWallCheckPoint.position.y - 2)
        {
            zombieController.SetBool("bClimb", true);
            RotateToClimbPose();
        }
    }

    float elapseTime = 0;
    void RotateToClimbPose()
    {
        if (elapseTime < 1)
        {
            transform.rotation *= Quaternion.Euler(45 * Time.deltaTime, 0, 0);
            transform.rotation *= Quaternion.Euler(0, 45 * Time.deltaTime, 0);
            transform.rotation *= Quaternion.Euler(0, 0, 30 * Time.deltaTime);
            transform.position += transform.up * 0.75f * Time.deltaTime;
            elapseTime += Time.deltaTime;
        }
    }

    void AnimateSweepFall()
    {
        zombieController.SetTrigger("trSweepFall");
        GameManager.instance.SetScore(1);
    }

    int health = 2;

    public void Die()
    {
        health--;
        if (health == 0)
            AnimateSweepFall();
    }


    [SerializeField]
    Transform theWall;
    void OnSpecialSkill()
    {
        gameObject.transform.SetParent(theWall);
    }

    public void DieEventInSweepFallAnimation()
    {
        health = 2;
        CommunicateManager.instance.ToSendToPool()?.SendToPool(gameObject);
    }
    public void GameOverEventInClimbAnimation()
    {
    }

}
