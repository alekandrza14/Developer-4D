using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DialogVoice : MonoBehaviour
{
    public Animator ДилогАнимация;
    public AudioSource ЗвукНастройка;
    public AudioClip[] РусскиийГолос;
    public float ВремяВСекундах;
    public bool НачатьПриСтарте;
    public void Start()
    {
        if (НачатьПриСтарте)
        {
            StartCoroutine(Wait(ВремяВСекундах));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<fristPersonControler>())
        {
            StartCoroutine(Wait(ВремяВСекундах));
        }
    }
    IEnumerator Wait(float sconds)
    {
        yield return new WaitForSeconds(sconds);

            ЗвукНастройка.clip = РусскиийГолос[Random.Range(0, РусскиийГолос.Length)];
        ЗвукНастройка.Play();
    }
    private void Update()
    {
      if(ДилогАнимация != null)  ДилогАнимация.SetBool("IsPlaying", ЗвукНастройка.isPlaying);
    }
}
