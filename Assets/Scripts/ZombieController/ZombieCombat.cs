using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCombat : MonoBehaviour, IDie, IReact
{
    Animator zombieController;
    private void OnEnable()
    {
        zombieController = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        zombieController.SetTrigger("trAttack");
    }
    private void OnTriggerExit(Collider other)
    {
        zombieController.SetTrigger("trOutAttack");
    }
    void OnCollisionEnter(Collision collision)
    {
        zombieController.SetTrigger("trAttack");
    }
    private void OnCollisionExit(Collision collision)
    {
        zombieController.SetTrigger("trAttack");
    }

    void ToReact()
    {
        zombieController.SetTrigger("trReact");
    }
    void ToDie()
    {
        zombieController.SetTrigger("trDie");
    }

    public void Die()
    {
        ToDie();
    }
    public void React()
    {
        ToReact();
    }

    [SerializeField]
    Transform theRightHand;
    [SerializeField]
    CommunicateManager communicator;

    public void CheckDamageAnimationEvent()
    {
        if(Physics.CheckSphere(theRightHand.position, 0.2f))
        {
            //IReact iReact = (IReact)communicator;
            //iReact?.React();
            communicator.CanReactThing("Character")?.React();
        }
    }
}
