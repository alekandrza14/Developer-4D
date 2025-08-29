using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionGameOver : MonoBehaviour
{
    public string scanePrison;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Ugroza>())
        {
            SceneManager.LoadScene(scanePrison);
        }
    }
}
