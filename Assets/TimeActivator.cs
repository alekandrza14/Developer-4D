using UnityEngine;

public class TimeActivator : MonoBehaviour
{
    public GameObject min;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("akt", 60);
    }

    // Update is called once per frame
    void akt()
    {
        min.SetActive(true);
    }
}
