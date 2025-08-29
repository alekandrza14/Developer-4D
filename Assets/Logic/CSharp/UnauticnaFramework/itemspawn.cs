using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class itemspawn : MonoBehaviour
{
    public string prefabname;
    public string Data;
    // Start is called before the first frame update


    // Update is called once per frame
    public void sp()
    {

        GameObject g = Instantiate(Resources.Load<GameObject>("items/" + prefabname), transform.position, transform.rotation);
        g .GetComponent<itemName>().ItemData = Data;



    }
  
}
