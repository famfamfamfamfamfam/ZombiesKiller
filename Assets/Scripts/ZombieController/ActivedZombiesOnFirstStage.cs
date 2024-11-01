using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivedZombiesOnFirstStage : MonoBehaviour
{
    Animator zombieController;
    Vector3 startPos;
    Quaternion startRo;

    private void OnEnable()
    {
        zombieController = GetComponent<Animator>();
    }

    private void Start()
    {
        startPos = Vector3.up * 2.25f + Vector3.forward * 87.2f;
        startRo = Quaternion.Euler(-90, 0, 0);
        SetUpStartPositon();
    }

    void SetUpStartPositon()
    {
        transform.position = startPos;
        transform.rotation = startRo;
    }
    void AnimateSweepFall()
    {
        if (true) // mau Zombie het
        {
            zombieController.SetTrigger("trSweepFall");
        }
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
            elapseTime += Time.deltaTime;
        }
    }


    public void DieEventInSweepFallAnimation()
    {
        gameObject.SetActive(false);
    }
    public void GameOverEventInClimbAnimation()
    {
    }

}
