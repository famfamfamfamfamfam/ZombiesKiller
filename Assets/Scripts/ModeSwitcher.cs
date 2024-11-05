using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ModeSwitcher : MonoBehaviour
{
    [SerializeField]
    GameObject FPPCam;
    [SerializeField]
    GameObject battleZom;
    [SerializeField]
    GameObject secondStageWeapon;
    [SerializeField]
    GameObject firstStageSpawn;

    private void Start()
    {
        battleZom.SetActive(false);
        secondStageWeapon.SetActive(false);
        StartCoroutine(Countdown());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            FPPCam.SetActive(!FPPCam.gameObject.activeSelf);
        }
    }

    private void OnDisable()
    {
        Destroy(firstStageSpawn);
        battleZom.SetActive(true);
        secondStageWeapon?.SetActive(true);
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);
    }
}
