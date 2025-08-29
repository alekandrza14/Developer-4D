using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bomb : MonoBehaviour
{
    float timer = 5;
    int PikOld =9;
    public Text TimeCounter;
    public AudioSource clip;
    public GameObject babah;
    
    private void Update()
    {
        timer-=Time.deltaTime;
        TimeCounter.text = "Sec : " + System.MathF.Round(timer,1);
        if (PikOld!=(int)timer)
        {
          if(clip)  clip.Play();
            PikOld = (int)timer;
        }
        if (timer < 0)
        {
            Instantiate(babah, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
