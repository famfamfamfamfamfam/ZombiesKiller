using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour, IOrderOfRunningStart, IStopTheGame
{
    [SerializeField]
    GameObject stScr, ndScr, spcButton, gOverScr;
    [SerializeField]
    TextMeshProUGUI stt;

    public void Init()
    {
        GameManager.instance.HasChanged += spcButtonOn;
        GameManager.instance.HasChanged += spcButtonOff;
        GameManager.instance.HasChanged += ndStOn;

        ndScr.SetActive(false);
        spcButton.SetActive(false);
        gOverScr.SetActive(false);
        stScr.SetActive(true);
    }

    void ndStOn(string s)
    {
        if (s == "secondStageOn")
        {
            stScr.SetActive(false);
            ndScr.SetActive(true);
        }
    }

    void spcButtonOn(string s)
    {
        if (s == "canTurnOnSkill")
            spcButton.SetActive(true);
    }

    void spcButtonOff(string s)
    {
        if (s == "turnOffButton")
            spcButton.SetActive(false);
    }

    public void gOverScrOn(string s)
    {
        Time.timeScale = 0;
        spcButton.SetActive(false);
        stScr.SetActive(false);
        ndScr.SetActive(false);
        gOverScr.SetActive(true);
        stt.text = s;
    }

    void OnDestroy()
    {
        GameManager.instance.HasChanged -= spcButtonOn;
        GameManager.instance.HasChanged -= spcButtonOff;
        GameManager.instance.HasChanged -= ndStOn;
    }
}