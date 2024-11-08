using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWallOnSpecialSkill : MonoBehaviour, IOnSpecialSkill
{
    float timeCount = 0;
    public void OnSpecialSkill()
    {
        CommunicateManager.instance.SwitchCam()?.SetUpTheCam();
        if (timeCount < 0.9f)
            transform.position += Vector3.up * 0.18f * Time.unscaledDeltaTime;//xem lai
        else if (timeCount < 1.5)
            transform.position += Vector3.down * 0.12f * Time.unscaledDeltaTime;
        else
        {
            timeCount = 0;
            Time.timeScale = 1;
            CommunicateManager.instance.SwitchCam()?.SetUpTheCam();
            return;
        }
        timeCount += Time.unscaledDeltaTime;
        Debug.Log(gameObject.transform.position);

    }


    void OnDestroy()
    {
        GameManager.instance.hasRunOnDestroy = true;
    }
}
