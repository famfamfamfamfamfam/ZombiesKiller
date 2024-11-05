using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommunicateManager : MonoBehaviour
{
    [SerializeField]
    ActivedZombiesOnFirstStage zom1;
    [SerializeField]
    ZombieCombat zom2;
    [SerializeField]
    CombatAnimation charac;

    public static CommunicateManager instance;

    private void OnEnable()
    {
        instance = this;
    }
    private void OnDisable()
    {
        instance = null;
    }

    public IDie CanDieThing(string thatThing)
    {
        if (thatThing == "Zombie1") return zom1;
        if (thatThing == "Zombie2") return zom2;
        if (thatThing == "Character") return charac;
        return null;
    }

    public IReact CanReactThing(string thatThing)
    {
        if (thatThing == "Zombie") return zom2;
        if (thatThing == "Character") return charac;
        return null;
    }

    public IIsPlayingAnimation MayBePlayingThing()
    {
        return charac;
    }

    public ISendToPool ToSendToPool(GameObject objSent)
    {
        return objSent.GetComponent<ISendToPool>();
    }
}
