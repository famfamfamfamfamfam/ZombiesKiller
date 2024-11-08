using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondStageUI : MonoBehaviour
{
    [SerializeField]
    Slider charHealth, zomHealth;

    void UpdateCharHealthValue(string s)
    {
        if (s == "charHealth")
            charHealth.value = GameManager.instance.charHealth;
    }

    void UpdateZomHealthValue(string s)
    {
        if (s == "zomHealth")
            zomHealth.value = GameManager.instance.zomHealth;
    }

    private void OnEnable()
    {
        charHealth.value = GameManager.instance.charHealth;
        zomHealth.value = GameManager.instance.zomHealth;
        GameManager.instance.HasChanged += UpdateCharHealthValue;
        GameManager.instance.HasChanged += UpdateZomHealthValue;
    }

    private void OnDisable()
    {
        GameManager.instance.HasChanged -= UpdateCharHealthValue;
        GameManager.instance.HasChanged -= UpdateZomHealthValue;
    }
}
