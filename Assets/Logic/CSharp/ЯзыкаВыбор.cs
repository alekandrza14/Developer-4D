using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ЯзыкаВыбор : MonoBehaviour
{
    public void ChargeSceneByNumber(string Lenguage)
    {
        File.WriteAllText("Язык", Lenguage);
        SceneManager.LoadScene(1);
    }
    public void ChargeSceneByString(string Lenguage)
    {
        File.WriteAllText("Язык", Lenguage);
        SceneManager.LoadScene(1);
    }
}
