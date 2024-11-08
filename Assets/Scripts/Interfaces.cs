using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public interface IDie
{
    void Die();
}
public interface IReact
{
    void React();
}

public interface ISendToPool
{
    void SendToPool(GameObject objSent);
}

public interface IIsPlayingAnimation
{
    bool IsPlaying();
}

public interface IOrderOfRunningStart
{
    void Init();
}

public interface IOnSpecialSkill
{
    void OnSpecialSkill();
}

public interface ISwitchCam
{
    void SetUpTheCam();
}

public interface IUnSetParent
{
    void UnSetParent();
}

public interface IAdjustTransform
{
    void AdjustTransform();
}

public interface IDash
{
    void Dash();
}

public interface IToTheShootingSight
{
    bool Input();
}

public interface ICountdown
{
    void CountdownText(int countNum);
}

public interface IMove
{
    void Move();
}

public interface IStopTheGame
{
    void gOverScrOn(string s);
}
