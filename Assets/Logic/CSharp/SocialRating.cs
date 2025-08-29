using UnityEngine;
using UnityEngine.UI;

public class SocialRating : MonoBehaviour
{
    public Text _lable;
    public int _rating = 100;
    void Update()
    {
        _rating += 1;
        _lable.text = "SocialRating : "+ _rating + " debuf(sosi)";
    }
}
