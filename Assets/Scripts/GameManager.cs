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
        instance = this;
    }
    private void OnDisable()
    {
        instance = null;
    }

    [SerializeField]
    List<GameObject> objsWaitingToRun;

    private void Start()
    {
        weaponAmount = 100;
        charHealth = 100;
        zomHealth = 100;


    }

    public int score { get; private set; }
    public void SetScore(int plusScore)
    {
        score += plusScore;
    }

    int minusAmount = 1;
    [HideInInspector]
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

    [HideInInspector]
    public int plusValue = 1;

    public int specialEnergy { get; private set; }
    public void SetSpecialEnergy()
    {
        specialEnergy += plusValue;
    }

    [HideInInspector]
    public int thresold = 5;

    int minusValue = 5;
    public int charHealth { get; private set; }
    public void SetCharHealth()
    {
        charHealth -= minusValue * 3;
    }

    public int zomHealth { get; private set; }
    public void SetZomHealth()
    {
        zomHealth -= minusValue;
    }

    [HideInInspector]
    public bool secondStageOn = false;
}
