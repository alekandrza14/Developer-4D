using UnityEngine;
using UnityEngine.UI;

public class Pissat : MonoBehaviour
{
    [SerializeField] GameObject piss;
    [SerializeField] GameObject pissun;
    [SerializeField] Toggle Type;
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Type.isOn)
        {
            GameObject obj = Instantiate(piss, pissun.transform.position, pissun.transform.rotation);
            obj.GetComponent<Rigidbody>().linearVelocity = transform.forward * 30;
        }
    }
}
