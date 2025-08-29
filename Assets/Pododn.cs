using UnityEngine;
using UnityEngine.SceneManagement;

public class Pododn : MonoBehaviour
{
    public int scene;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<finish>())
        {
            SceneManager.LoadScene(scene);
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
