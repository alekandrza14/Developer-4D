using UnityEngine;
using UnityEngine.UI;

public class DayCounter : MonoBehaviour
{
    public Text Days;
    public static int DayCount = 0;
    void Start()
    {
        Days.text = "Δενό " + DayCount.ToString();
    }
}
