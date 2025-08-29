
using System.Windows;
using UnityEngine;

public class OpenBowser : MonoBehaviour
{
    public void Donat()
    {
        string target = "https://boosty.to/arua";
        //Use no more than one assignment when you test this code.
        //string target = "ftp://ftp.microsoft.com";
        //string target = "C:\\Program Files\\Microsoft Visual Studio\\INSTALL.HTM";
       
            System.Diagnostics.Process.Start(target);
        
    }
}
