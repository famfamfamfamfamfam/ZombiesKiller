using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPPCamera : MonoBehaviour, IOrderOfRunningStart
{
    [SerializeField]
    Joystick joystick;
    [SerializeField]
    Transform theWall;
    [SerializeField]
    GameObject camSight;
    Camera thisCam;

    private void OnEnable()
    {
        camSight.SetActive(true);
        thisCam = GetComponent<Camera>();
    }

    private void OnDisable()
    {
        camSight.SetActive(false);
    }

    public void Init()
    {
        transform.position = theWall.position - Vector3.forward * 15;
    }
    private void Update()
    {
        CaculateAxis();
        MoveSight();
        Shooting();
        KickBack();
    }

    Vector3 mousePos, axis;
    void CaculateAxis()
    {
        mousePos = Input.mousePosition;
        mousePos.z = 0.02f;
        mousePos = thisCam.ScreenToWorldPoint(mousePos);
        axis = mousePos - transform.position;
        axis.z = 0;
        axis = axis.normalized;
    }

    Vector3 joystickMove;
    void MoveSight()
    {
        if (Application.platform != RuntimePlatform.Android)
            transform.position += axis * 7.5f * Time.deltaTime;
        else
        {
            joystickMove = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
            transform.position += joystickMove * 5;
        }
    }

    Ray shootingRay;
    RaycastHit hit;
    [SerializeField]
    LayerMask zombieLayerMask;

    void Shooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shootingRay = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(shootingRay, out hit, 115, zombieLayerMask) && GameManager.instance.weaponAmount > 0)
            {
                CommunicateManager.instance.CanDieThing(hit.collider.gameObject)?.Die();
            }
            if (GameManager.instance.weaponAmount > 0)
                GameManager.instance.DecreaseValidDamage();
            kick = true;
        }
    }
    bool kick = false;
    int frameCount = 1;
    void KickBack()
    {
        if (kick)
        {
            if (frameCount < 21)
            {
                transform.rotation *= Quaternion.Euler(-1f / 10, 0f, 0f);
                frameCount++;
            }
            else if (frameCount < 51)
            {
                transform.rotation *= Quaternion.Euler(1f / 15, 0f, -0f);
                frameCount++;
            }
            else
            {
                frameCount = 1;
                kick = false;
            }
        }
    }
}
