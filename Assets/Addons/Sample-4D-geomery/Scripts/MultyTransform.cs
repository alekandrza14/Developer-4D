using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[ExecuteAlways]
public class MultyTransform : MonoBehaviour
{
    public float W_Position,H_Position;
    public Text res;
    private void Update()
    {
        MultyObject[] g = FindObjectsByType<MultyObject>(FindObjectsSortMode.InstanceID);
        if (!Application.isPlaying) foreach (MultyObject obj in g)
        {
            obj.ProjectionUpdate();
        }
        res.text = "W : " + W_Position.ToString();
    }
    private void OnGUI()
    {
      //  GUI.Label(new Rect(0,0,600,60),"World Position x : " + transform.position.x + " y : " + transform.position.y + " z : " + transform.position.z + " w : " + W_Position + " h : " + H_Position);
    }
}
