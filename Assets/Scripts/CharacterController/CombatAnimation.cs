using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatAnimation : MonoBehaviour
{
    Animator characterController;
    private void OnEnable()
    {
        characterController = GetComponent<Animator>();
    }

    private void Update()
    {
        ToAttack();
        ToAnimateDashing();
        DashForward();
    }

    void ToAttack()
    {
        if (Input.GetMouseButtonDown(0))
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
            characterController.applyRootMotion = true;
        }
        else
        {
            characterController.applyRootMotion = false;
        }
    }

    void ToReact()
    {
        characterController.SetTrigger("trReact");
    }

    void ToDie()
    {
        characterController.SetTrigger("trDie");
    }

}
