using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void OnEnable()
    {
        if (instance != null) instance = null;
        instance = this;
    }

    [SerializeField]
    List<GameObject> objsWaitingToRun;
    [SerializeField]
    GameObject countDownObj;
    private void Start()
    {
        weaponAmount = 100;
        charHealth = 100;
        zomHealth = 100;
        countDownObj.SetActive(false);
        turnOn = false;
        foreach (GameObject obj in objsWaitingToRun)
        {
            obj.GetComponent<IOrderOfRunningStart>()?.Init();
        }

    }

    public int score { get; private set; }
    public void SetScore(int plusScore)
    {
        score += plusScore;
    }

    int minusAmount = 1;
    [NonSerialized]
    public int plusAmount = 20;
    public int weaponAmount { get; private set; }
    public void AddValidDamage()
    {
        weaponAmount += plusAmount;
    }
    public void DecreaseValidDamage()
    {
        weaponAmount -= minusAmount;
    }

    [NonSerialized]
    public int plusValue = 1;

    public int specialEnergy { get; private set; }
    public void SetSpecialEnergy()
    {
        if (specialEnergy < thresold)
            specialEnergy += plusValue;
    }

    [NonSerialized]
    public int thresold = 1;

    int minusValue = 5;
    public int charHealth { get; private set; }
    public void SetCharHealth()
    {
        if (charHealth == 0) CommunicateManager.instance.CanDieThing("Character")?.Die();
        charHealth -= minusValue * 3;
    }

    public int zomHealth { get; private set; }
    public void SetZomHealth()
    {
        if (zomHealth == 0) CommunicateManager.instance.CanDieThing("Zombie")?.Die();
        zomHealth -= minusValue;
    }

    [NonSerialized]
    public bool secondStageOn = false;

    [NonSerialized]
    public bool hasRunOnDestroy = false;

    [NonSerialized]
    public bool turnOn;

    private void Update()
    {
        //if (thresold == specialEnergy)
            Debug.Log(specialEnergy);
        if (Input.GetKeyDown(KeyCode.Space) && thresold == specialEnergy)
        {
            if (!secondStageOn) Time.timeScale = 0;
            else turnOn = true;
            specialEnergy = 0;
        }
        if (Time.timeScale == 0)
        {
            CommunicateManager.instance.SpecialSkill("Zombie1")?.OnSpecialSkill();
            CommunicateManager.instance.SpecialSkill("TheWall")?.OnSpecialSkill();
        }
        if (turnOn)
        {
            countDownObj.SetActive(true);
            CommunicateManager.instance.SpecialSkill("TheKnife")?.OnSpecialSkill();
        }
    }
}
