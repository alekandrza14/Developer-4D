using UnityEngine;

public class PlayerJumpCollider : MonoBehaviour
{
    public Vector3 glabalVec;
    public Vector3 localVec;
    void Start()
    {
        fristPersonControler player = FindAnyObjectByType<fristPersonControler>();
        player.GetComponent<Rigidbody>().AddForce(glabalVec, ForceMode.Impulse);
        player.GetComponent<Rigidbody>().AddForce(
            (player.transform.right * localVec.x)
            + (player.transform.up * localVec.y)
            + (player.transform.forward * localVec.z), ForceMode.Impulse);
    }
}
