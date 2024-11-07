using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(Duration());
    }
    IEnumerator Duration()
    {
        yield return new WaitForSeconds(5);
        GameManager.instance.turnOn = false;
        gameObject.SetActive(false);
    }
}
