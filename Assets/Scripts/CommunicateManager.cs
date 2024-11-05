using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommunicateManager : MonoBehaviour
{
    [SerializeField]
    ZombieCombat zom2;
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

    IDie zom1;

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

    public ISendToPool ToSendToPool(GameObject obj)
    {
        zom1 = obj.GetComponent<IDie>();
        CanDieThing("Zombie1")?.Die();
        return zomPool;
    }
}
