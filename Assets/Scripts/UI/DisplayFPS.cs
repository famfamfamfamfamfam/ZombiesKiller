using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayFPS : MonoBehaviour
{
    TextMeshProUGUI fpsDis;
    int fps;
    void Start()
    {
        fpsDis = GetComponent<TextMeshProUGUI>();
        StartCoroutine(ToDisplayFPS());
    }

    void Update()
    {
        fps = (int)(1 / Time.deltaTime);
    }

    IEnumerator ToDisplayFPS()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(0.2f);
            fpsDis.text = fps.ToString();
        }
    }

    private void OnDestroy()
    {
        StopCoroutine(ToDisplayFPS());
    }
}
