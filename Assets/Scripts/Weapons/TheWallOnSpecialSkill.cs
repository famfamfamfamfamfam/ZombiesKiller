using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWallOnSpecialSkill : MonoBehaviour, IOnSpecialSkill
{
    float timeCount = 0;
    public void OnSpecialSkill()
    {
        if (timeCount < 1.0f)
            transform.position += Vector3.up * 4 * Time.unscaledDeltaTime;
        else if (timeCount < 1.25)
            transform.position += Vector3.down * 16 * Time.unscaledDeltaTime;
        else
        {
            timeCount = 0;
            //CommunicateManager.instance.UnSetParent()?.UnSetParent();
            Time.timeScale = 1;
            GameManager.instance.oneTimeUse = true;
            CommunicateManager.instance.SwitchCam()?.SetUpTheCam();
            return;
        }
        timeCount += Time.unscaledDeltaTime;
    }


    void OnDestroy()
    {
        //GameManager.instance.hasRunOnDestroy = true;
    }
}
