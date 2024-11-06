using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ModeSwitcher : MonoBehaviour, IOrderOfRunningStart
{
    [SerializeField]
    GameObject FPPCam;
    [SerializeField]
    GameObject battleZom;
    [SerializeField]
    GameObject secondStageWeapon;
    [SerializeField]
    GameObject firstStageSpawn;

    public void Init()
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

    private void OnDestroy()
    {
        Destroy(firstStageSpawn);
        if (canAccess)
        {
            FPPCam.SetActive(false);
            battleZom.SetActive(true);
            secondStageWeapon.SetActive(true);
            GameManager.instance.thresold = 100;
            GameManager.instance.plusValue = GameManager.instance.score;
            GameManager.instance.plusAmount = 5;
            GameManager.instance.secondStageOn = true;
            canAccess = false;
        }
    }
    bool canAccess = false;
    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(60);
        canAccess = true;
        Destroy(gameObject);
    }
}
