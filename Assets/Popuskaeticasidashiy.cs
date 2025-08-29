using UnityEngine;
using UnityEngine.SceneManagement;

public class Popuskaeticasidashiy : MonoBehaviour
{
    public GameObject sidyahiytochno;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Ugroza>())
        {
            Instantiate(sidyahiytochno,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
