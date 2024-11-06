using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSight : MonoBehaviour
{
    [SerializeField]
    GameObject cam;
    private void OnDestroy()
    {
        Destroy(cam);
    }
}
