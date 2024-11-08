using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CombatAnimation : MonoBehaviour, IDie, IReact, IIsPlayingAnimation, IDash
{
    Animator characterController;
    Rigidbody characterRigidbody;
    private void OnEnable()
    {
        characterController = GetComponent<Animator>();
        characterRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ToAttack();
        ToAnimateDashing(Input.GetMouseButtonDown(1));
        DashForward();
    }

    void ToAttack()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.instance.secondStageOn)
        {
            characterController.SetTrigger("trAttack");
        }
    }
    void ToAnimateDashing(bool input)
    {
        if (input)
        {
            characterController.SetTrigger("trDash");
        }
    }

    void DashForward()
    {
        if (characterController.GetCurrentAnimatorStateInfo(0).IsName("Dash"))
        {
            characterRigidbody.isKinematic = true;
            characterController.applyRootMotion = true;
        }
        else
        {
            characterRigidbody.isKinematic = false;
            characterController.applyRootMotion = false;
        }
    }

    void ToReact()
    {
        if (!characterController.GetCurrentAnimatorStateInfo(0).IsName("Die"))
            characterController.SetTrigger("trReact");
        GameManager.instance.SetCharHealth();
    }

    void ToDie()
    {
        characterController.SetTrigger("trDie");
    }

    public void Die()
    {
        ToDie();
        CommunicateManager.instance.MovingAgain()?.Move();
    }
    public void React()
    {
        ToReact();
    }
    public bool IsPlaying()
    {
        return characterController.GetCurrentAnimatorStateInfo(0).IsName("Attack");
    }

    public void Dash()
    {
        ToAnimateDashing(true);
        DashForward();
    }


    public void GameOverEventInDieAnimation()
    {
        GameManager.instance.gameResult = "YOU ARE EATEN";
        CommunicateManager.instance.GameStop()?.gOverScrOn(GameManager.instance.gameResult);
    }
}
