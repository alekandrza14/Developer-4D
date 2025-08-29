using UnityEngine;

public class Bonus : MonoBehaviour
{
    public string BonusType;
    void Start()
    {
        VarSave.SetInt("Bonus_"+ BonusType,1);
    }
}
