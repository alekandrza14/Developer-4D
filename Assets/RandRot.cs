using UnityEngine;
[ExecuteInEditMode]
public class RandRot : MonoBehaviour
{
    public bool Rot;
    void Update()
    {
        if (Rot)
        {
            transform.Rotate(Random.Range(-1,2), Random.Range(-1, 2), Random.Range(-1, 2));
            Rot = false;
        }
    }
}
