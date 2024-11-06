using System.Collections;
using System.Collections.Generic;
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

    private void Start()
    {
        weaponAmount = 50;
        charHealth = 100;
        zomHealth = 100;
    }


    public int score { get; private set; }
    public void SetScore(int plusScore)
    {
        score += plusScore;
    }


    int minusAmount = 1;
    public int plusAmount = 15;
    public int weaponAmount { get; private set; }
    public void AddValidDamage()
    {
        weaponAmount += plusAmount;
    }
    public void DecreaseValidDamage()
    {
        weaponAmount -= minusAmount;
    }

    public int plusValue = 1;

    public int specialEnergy { get; private set; }
    public void SetSpecialEnergy()
    {
        specialEnergy += plusValue;
    }

    public int thresold = 5;


    int minusValue = 5;
    public int charHealth { get; private set; }
    public void SetCharHealth()
    {
        charHealth -= minusValue;
    }

    public int zomHealth { get; private set; }
    public void SetZomHealth()
    {
        zomHealth -= minusValue;
    }
}
