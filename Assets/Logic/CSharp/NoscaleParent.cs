using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum NoscaleParentSettings
{
    noMove = 0, noRotate = 1, MoveandRotate = 2, palyerY = 3, PlayerRayEnd = 4, PayerCamera = 5,rotateCameraP = 6, PlayerPos = 7, RotPlayer = 8, PatrulPlayer = 9, onlyScale = 10, Rand1MCube = 11
}

public class NoscaleParent : MonoBehaviour
{
    public Transform Obj;
    Vector3 target;
    Vector3 diretional;
    float timer;
    [SerializeField] NoscaleParentSettings settings;
    private void Start()
    {
        if (settings == NoscaleParentSettings.PatrulPlayer)
        {
            transform.SetParent(new GameObject().transform);
        }
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (settings == NoscaleParentSettings.noMove)
        {
            transform.rotation = Obj.rotation;
        }
        if (settings == NoscaleParentSettings.noRotate)
        {
            transform.position = Obj.position;
        }
        if (settings == NoscaleParentSettings.MoveandRotate)
        {
            transform.position = Obj.position;
            transform.rotation = Obj.rotation;
        }
        if (settings == NoscaleParentSettings.palyerY)
        {
            transform.position = new Vector3(transform.position.x, Obj.transform.position.y, transform.position.z);
        }
        if (settings == NoscaleParentSettings.PlayerRayEnd)
        {
        }
        if (settings == NoscaleParentSettings.PayerCamera)
        {
        }
        if (settings == NoscaleParentSettings.rotateCameraP)
        {
        }
        if (settings == NoscaleParentSettings.PlayerPos)
        {
        }
        if (settings == NoscaleParentSettings.RotPlayer)
        {
            transform.Rotate(0, 180, 0);
        }
        if (settings == NoscaleParentSettings.PatrulPlayer)
        {
            if (timer > 5) 
            {
                timer = 0;
            }
            transform.position = target;
            transform.Rotate(0, 180, 0);
        }
        if (settings == NoscaleParentSettings.onlyScale)
        {
            transform.localScale = Obj.localScale;
        }
        if (settings == NoscaleParentSettings.Rand1MCube)
        {
            transform.position = Obj.position;
        }
    }
}
