using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ModeSwitcher : MonoBehaviour, IOrderOfRunningStart, ISwitchCam
{
    [SerializeField]
    GameObject FPPCam;
    [SerializeField]
    GameObject battleZom;
    [SerializeField]
    GameObject secondStageWeapon;
    [SerializeField]
    GameObject firstStageSpawn;
    [SerializeField]
    GameObject freeCam;


    public void Init()
    {
        freeCam.SetActive(false);
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
            GameManager.instance.thresold = 1;
            GameManager.instance.plusValue = GameManager.instance.score;
            GameManager.instance.plusAmount = 5;
            GameManager.instance.secondStageOn = true;
            canAccess = false;
        }
    }
    bool canAccess = false;
    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(5);
        int count = 3;
        for (int i = 0; i < 3; i++)
        {
            //text
            yield return new WaitForSeconds(1);
            count--;
        }
        canAccess = true;
        Destroy(gameObject);
    }

    public void SetUpTheCam()
    {
        if (Time.timeScale == 0) freeCam.SetActive(true);
        else freeCam.SetActive(false);
    }
}
