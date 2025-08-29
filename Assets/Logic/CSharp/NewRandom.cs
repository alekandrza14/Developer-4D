using UnityEngine;
[ExecuteAlways]
[ExecuteInEditMode]
public class NewRandom : MonoBehaviour
{
    void Start()
    {
        transform.position += new Vector3(0,Random.Range(-20,20),0);
        Destroy(this);
    }
}
