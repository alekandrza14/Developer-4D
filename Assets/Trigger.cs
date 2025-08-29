using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject obj;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<fristPersonControler>())
        {
            obj.SetActive(true);
        }
    }
}
