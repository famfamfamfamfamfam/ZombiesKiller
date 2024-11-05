using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommunicateManager : MonoBehaviour
{
    [SerializeField]
    ZombieCombat zom;
    [SerializeField]
    CombatAnimation charac;
    [SerializeField]
    ReviveZombie zomPool;

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
        if (thatThing == "Zombie") return zom;
        if (thatThing == "Character") return charac;
        return null;
    }

    public IDie CanDieThing(GameObject obj)
    {
        return obj.GetComponent<IDie>();
    }

    public IReact CanReactThing(string thatThing)
    {
        if (thatThing == "Zombie") return zom;
        if (thatThing == "Character") return charac;
        return null;
    }

    public IIsPlayingAnimation MayBePlayingThing()
    {
        return charac;
    }

    public ISendToPool ToSendToPool()
    {
        return zomPool;
    }
}
