using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMoney : MonoBehaviour
{
    public GameObject money;
    void Update()
    {
        RaycastHit hit = MainRay.MainHit;
        if (hit.collider != null && Input.GetKeyDown(KeyCode.Mouse0))
        {
          if(hit.collider.gameObject == gameObject)  Instantiate(money,hit.point,Quaternion.identity);
           
        }
    }
}
