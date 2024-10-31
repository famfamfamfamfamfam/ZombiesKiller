using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    Transform head;
    Animator characterController;
    float horizontalValue, verticalValue;
    float moveSpeed = 5;

    private void OnEnable()
    {
        characterController = GetComponent<Animator>();
    }
    private void Update()
    {
        horizontalValue = Input.GetAxis("Horizontal");
        verticalValue = Input.GetAxis("Vertical");
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
                transform.position += transform.forward * moveSpeed * Time.deltaTime;
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
        dir = new Vector3(horizontalValue, 0, verticalValue);
        if (dir != Vector3.zero)
            transform.forward = head.rotation * dir;
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
