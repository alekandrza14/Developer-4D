using UnityEngine;

public class RandomColour : MonoBehaviour
{
    public MeshRenderer[] meshGrawing;
    void Start()
    {
        Color col = new Color(Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        foreach (MeshRenderer graw in meshGrawing)
        {
            graw.material.color = col;
        }
    }
}
