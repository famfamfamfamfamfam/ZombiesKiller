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
    [SerializeField]
    ReviveZombie zomPool;//xem lai

    public IDie CanDieThing(string thatThing)
    {
        if (thatThing == "Zombie1" && zom1 is IDie) return zom1;
        if (thatThing == "Zombie2" && zom2 is IDie) return zom2;
        if (thatThing == "Character" && charac is IDie) return charac;
        return null;
    }

    public IReact CanReactThing(string thatThing)
    {
        if (thatThing == "Zombie" && zom2 is IReact) return zom2;
        if (thatThing == "Character" && charac is IReact) return charac;
        return null;
    }

    public ISendToPool ToSendToPool()
    {
        if (zomPool is ISendToPool) return zomPool;
        return null;
    }
}
