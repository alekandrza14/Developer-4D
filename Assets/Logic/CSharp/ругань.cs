using UnityEngine;

public class ругань : MonoBehaviour
{
    public GameObject point;
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.F)) if (other.gameObject.GetComponent<HpCharactor>())
            {
                other.gameObject.GetComponent<HpCharactor>();
              //other.transform.localScale = other.transform.localScale * Random.Range(0.9f, 1f);
                other.transform.localScale = new Vector3(other.transform.localScale.x, other.transform.localScale.y * Random.Range(0.95f, 0.98f), other.transform.localScale.z);
            }
    }
    private void Update()
    {
        transform.position = point.transform.position;
        transform.rotation = point.transform.rotation;
    }
}
