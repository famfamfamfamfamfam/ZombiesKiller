using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWallOnSpecialSkill : MonoBehaviour
{
    void OnSpecialSkill()
    {
        transform.position += Vector3.up * Time.unscaledDeltaTime;
    }
}
