using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    Transform head;
    Animator characterController;
    Rigidbody characterRigidbody;
    float horizontalValue, verticalValue;
    float moveSpeed = 5;

    private void OnEnable()
    {
        characterController = GetComponent<Animator>();
        characterRigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        horizontalValue = Input.GetAxis("Horizontal");
        verticalValue = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        NavigateCharacter();
        Moving();

    }

    void Moving()
    {
        if (!AnyAnimationIsPlaying())
        {
            if (horizontalValue != 0 || verticalValue != 0)
            {
                characterController.SetBool("bStopMoving", false);
                characterController.SetBool("bMoving", true);
                characterRigidbody.MovePosition(transform.position + transform.forward * moveSpeed * Time.fixedDeltaTime);
            }
            else if (horizontalValue == 0 && verticalValue == 0)
            {
                characterController.SetBool("bStopMoving", true);
                characterController.SetBool("bMoving", false);
            }
        }
    }
    string[] animationNames = {"Attack", "Dash", "React", "Die"};
    bool AnyAnimationIsPlaying()
    {
        for (int i = 0; i < animationNames.Length; i++)
        {
            if (characterController.GetCurrentAnimatorStateInfo(0).IsName(animationNames[i]))
                return true;
        }
        return false;
    }
    Vector3 dir;
    void NavigateCharacter()
    {
        if (!AnyAnimationIsPlaying())
        {
            dir = new Vector3(horizontalValue, 0, verticalValue);
            if (dir != Vector3.zero)
                characterRigidbody.MoveRotation(Quaternion.LookRotation(head.rotation * dir));
        }
    }

    private void LateUpdate()
    {
        SetUpHead();
    }

    void SetUpHead()
    {
        head.position = transform.position + transform.up * 1.5f;
    }


}
