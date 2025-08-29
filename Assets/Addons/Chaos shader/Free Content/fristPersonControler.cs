using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum person
{
    first, trid
}
public class fristPersonControler : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject[] g;
    public person camRejime;
    public LayerMask layerMask;
    public LayerMask layerMask1;
    Camera _camera;
    [SerializeField] MultyTransform multyTransform;
    static private fristPersonControler find;
    public static fristPersonControler main()
    {
        if (!find)
        {
            find = FindAnyObjectByType<fristPersonControler>();
        }
        return find;
    }
    void Update()
    {
        Ray r = new Ray(transform.position,Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(r,out hit))
        {
            if (hit.distance <= 1.5f && Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(Vector3.up*(50 * Time.deltaTime) * (VarSave.GetInt("Bonus_Jump") == 1 ? 3 : 1), ForceMode.Impulse);
            }
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            g[2].transform.rotation = g[1].transform.rotation;
            if (camRejime == person.first)
            {
                camRejime = person.trid;
            }
            else if (camRejime == person.trid)
            {
                camRejime = person.first; 
            }
        }
        if (camRejime == person.first)
        {
            _camera = g[2].GetComponent<Camera>();
            _camera.cullingMask = layerMask;
        }
        if (camRejime == person.trid)
        {
            _camera = g[2].GetComponent<Camera>();
            _camera.cullingMask = layerMask1;
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {

            g[0].transform.Rotate(0, Input.GetAxisRaw("Mouse X") * (150f * Time.fixedDeltaTime), 0);
            if (camRejime == person.first)
                g[2].transform.Rotate(-Input.GetAxisRaw("Mouse Y") * (150f * Time.fixedDeltaTime), 0, 0);
            if (camRejime == person.trid)
                g[1].transform.Rotate(-Input.GetAxisRaw("Mouse Y") * (150f * Time.fixedDeltaTime), 0, 0);
            if (camRejime == person.first)
            {
                g[2].transform.position = g[1].transform.position;
            }
            if (camRejime == person.trid)
            {
                Ray r1 = new(g[1].transform.position, -g[1].transform.forward);
                RaycastHit hit1;
                float distcam = 0;
                // CamDistanceMult
                float dist = (6 + distcam) * transform.localScale.y;
                if (Globalprefs.sit_player) distcam = 5; else distcam = 0;
                if (UnityEngine.Physics.Raycast(r1, out hit1))
                {
                    if (hit1.collider != null)
                    {
                        if (hit1.distance < dist)
                        {

                            g[2].transform.position = hit1.point;
                        }
                        if (hit1.distance > dist)
                        {

                            g[2].transform.position = g[1].transform.position - g[1].transform.forward * (dist);
                        }
                    }
                    else
                    {
                        g[2].transform.position = g[1].transform.position - g[1].transform.forward * (dist);
                    }
                }
                else
                {
                    g[2].transform.position = g[1].transform.position - g[1].transform.forward * (dist);
                }
            }

            Cursor.lockState = CursorLockMode.Locked;
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Cursor.lockState = CursorLockMode.None;
        }
       if((rb.linearVelocity.x+ rb.linearVelocity.z) <= 1) rb.MovePosition( ((transform.right * Input.GetAxisRaw("Horizontal")+ transform.forward * Input.GetAxisRaw("Vertical"))/6)* (VarSave.GetInt("Bonus_Speed") == 1 ? 3 : 1) + transform.position);
        multyTransform.W_Position += Input.GetAxisRaw("Vertical1") * Time.deltaTime * 3;
    }
}
