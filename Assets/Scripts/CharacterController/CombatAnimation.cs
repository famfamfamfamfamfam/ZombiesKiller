using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatAnimation : MonoBehaviour, IDie, IReact, IIsPlayingAnimation
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
        ToAnimateDashing();
        DashForward();
    }

    void ToAttack()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.instance.secondStageOn)
        {
            characterController.SetTrigger("trAttack");
        }
    }
    void ToAnimateDashing()
    {
        if (Input.GetMouseButtonDown(1))
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
    }
    public void React()
    {
        ToReact();
    }
    public bool IsPlaying()
    {
        return characterController.GetCurrentAnimatorStateInfo(0).IsName("Attack");
    }

}
