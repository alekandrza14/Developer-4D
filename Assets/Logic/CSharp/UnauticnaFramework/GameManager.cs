using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[System.Serializable]
public class useeffect
{
    public string effect = "";
    public float time = 0;
    public useeffect(string name, float secoundstime)
    {
        this.effect = name;
        this.time = secoundstime;
    }
    public useeffect()
    {
    }
}
public class playerdata
{
    
    static public useeffect[] effects = new useeffect[]
    {
        new useeffect(),
        new useeffect(),
        new useeffect(),
        new useeffect(),
        new useeffect(),
        new useeffect(),
        new useeffect(),
        new useeffect(),
        new useeffect(),
        new useeffect(),
        new useeffect(),
        new useeffect(),
        new useeffect(),
        new useeffect(),
        new useeffect(),
        new useeffect(),
        new useeffect()
    };
    static public useeffect[] Paniceffect = new useeffect[1]
    {
        new useeffect()
    };
    static public void checkeffect()
    {
        
        for (int i = 0; i < playerdata.effects.Length; i++)
        {
            
            if (i < playerdata.effects.Length)
            {


                if (playerdata.effects[i].time <= 0)
                {
                    playerdata.effects[i].effect = "";
                }
                if (playerdata.effects[i].time >= 0)
                {
                    playerdata.effects[i].time -= Time.deltaTime;
                }

            }
        }
        if (playerdata.Paniceffect[0].time <= 0)
        {
            playerdata.Paniceffect[0].effect = "";
        }
        if (playerdata.Paniceffect[0].time >= 0)
        {
            playerdata.Paniceffect[0].time -= Time.deltaTime;
        }

    }
    static public void Loadeffect()
    {
        for (int i = 0; i < playerdata.effects.Length; i++)
        {
            useeffect[] us1 = new useeffect[1] {
               new useeffect()
           };
            if (VarSave.ExistenceVar("effect_" + i))
            {
                us1[0] = JsonUtility.FromJson<useeffect>(VarSave.GetString("effect_" + i));

            }

            playerdata.effects[i] = us1[0];
        }
        useeffect[] us = new useeffect[1] {
               new useeffect()
           };
        if (VarSave.ExistenceVar("effect_" + "panic"))
        {


            us[0] = JsonUtility.FromJson<useeffect>(VarSave.GetString("effect_" + "panic"));

        }

        playerdata.Paniceffect[0] = us[0];
    }
    static public void Saveeffect()
    {
        for (int i = 0; i < playerdata.effects.Length; i++)
        {


            VarSave.SetString("effect_" + i, JsonUtility.ToJson(playerdata.effects[i]));



        }

        VarSave.SetString("effect_" + "panic", JsonUtility.ToJson(playerdata.Paniceffect[0]));
    }
    static public void FreezeAlleffect()
    {
        for (int i = 0; i < playerdata.effects.Length; i++)
        {


            playerdata.effects[i].time = float.PositiveInfinity;



        }

    }
    static public void Addeffect(string name, float secoundstime)
    {
        for (int i = 0; i < playerdata.effects.Length; i++)
        {
            if (playerdata.effects[i].effect == "")
            {
                playerdata.effects[i].effect = name;
                playerdata.effects[i].time = secoundstime;
                i = playerdata.effects.Length;
            }
        }
    }
    static public void SetPaniceffect(string name, float secoundstime)
    {
        playerdata.Paniceffect[0].effect = name;
        playerdata.Paniceffect[0].time = secoundstime;
    }
    static public void Cleareffect()
    {
        for (int i = 0; i < playerdata.effects.Length; i++)
        {
            playerdata.effects[i].effect = "";
            playerdata.effects[i].time = 0;
        }
    }
    static public useeffect Geteffect(string name)
    {
        useeffect ef = null;
        for (int i = 0; i < playerdata.effects.Length; i++)
        {
            if (playerdata.effects[i].effect == name)
            {
                ef = playerdata.effects[i];
            }
        }
        if (playerdata.Paniceffect[0].effect != "")
        {
            ef = playerdata.Paniceffect[0];
        }
        return ef;
    }
    static public void Upeffect(string name, float secoundstime)
    {
        for (int i = 0; i < playerdata.effects.Length; i++)
        {
            if (playerdata.effects[i].effect == name)
            {
                playerdata.effects[i].time += secoundstime;
            }
        }
        if (playerdata.Paniceffect[0].effect != "")
        {
            playerdata.Paniceffect[0].time += secoundstime;
        }
    }
    static public useeffect hasClearEffect(string name)
    {
        useeffect ef = null;
        for (int i = 0; i < playerdata.effects.Length; i++)
        {
            if (playerdata.effects[i].effect == name)
            {
                ef = playerdata.effects[i];

                playerdata.effects[i].effect = "";
                playerdata.effects[i].time = 0;
            }
        }
        if (playerdata.Paniceffect[0].effect != "")
        {
            ef = playerdata.Paniceffect[0];

            playerdata.Paniceffect[0].effect = "";
            playerdata.Paniceffect[0].time = 0;
        }

        return ef;
    }
    public static int overload()
    {
        int defult = 1;
        if (playerdata.Geteffect("overload") != null)
        {
            defult = 2;
        }
        return defult;
    }
}
public class currentAtackk
{

}
public class GameManager : MonoBehaviour
{
    public static string saveid;
 
  
    static public void GetUF()
    {
        
    }
    static public Ray pprey()
    {
        Ray r = new Ray();
        



            r = Camera.main.ScreenPointToRay(Input.mousePosition);
            //FindFirstObjectByType<Logic_tag_3>().GetComponent<Camera>().targetDisplay = 2;
       
      
        return r;

    }
    static public void load(Transform transform)
    {

        Transform player = FindAnyObjectByType<fristPersonControler>().transform;

        player.transform.position = transform.position;
        


    }

    static public void fall(GameObject other)
    {

       


    }
    static public void chargescene(int scene)
    {
        

            SceneManager.LoadScene(scene);
            
      


    }
    static public int scene = 0;
  

  
    //Photon.Realtime.RoomOptions roomOptions = new Photon.Realtime.RoomOptions();
  //  roomOptions.MaxPlayers = 3;
     //   PhotonNetwork.JoinOrCreateRoom(musave.saveid + musave.scene, roomOptions, TypedLobby.Default);
    
  
  
}
