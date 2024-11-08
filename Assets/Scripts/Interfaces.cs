using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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