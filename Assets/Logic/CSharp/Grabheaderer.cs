using UnityEngine;

public class Grabheaderer : MonoBehaviour
{
    Transform gun;GameObject bullet;
    void Update()
    {
        RaycastHit hit = MainRay.MainHit;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (hit.collider.GetComponent<GrabItem>())
            {
                hit.collider.GetComponent<GrabItem>().grabobj.transform.SetParent(transform);
                hit.collider.GetComponent<GrabItem>().grabobj.transform.position = transform.position;
                hit.collider.GetComponent<GrabItem>().grabobj.transform.rotation = transform.rotation;
                gun = hit.collider.GetComponent<GrabItem>().gunobj.transform;
                bullet = hit.collider.GetComponent<GrabItem>().bulletobj;
            }
            if (gun != null)
            {
                GameObject obj = Instantiate(bullet, gun.transform.position, gun.transform.rotation);
                obj.GetComponent<Rigidbody>().linearVelocity = gun.transform.forward * 30;
            }
        }

    }
}
