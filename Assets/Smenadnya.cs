using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Smenadnya : MonoBehaviour
{
    public Animator shadow;
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<fristPersonControler>())
        {
            StartCoroutine(Shadow());
        }
    }
    public IEnumerator Shadow()
    {
        shadow.SetTrigger("Shadow");
        yield return new WaitForSeconds(1.5f);
        DayCounter.DayCount++;
        SceneManager.LoadScene(2);
    }
}
