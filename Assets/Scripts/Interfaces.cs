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
    void SendToPool();
}