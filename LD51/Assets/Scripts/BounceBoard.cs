using UnityEngine;
using System.Collections;
using Sirenix.OdinInspector;
using System.Collections.Generic;

public class BounceBoard : MonoBehaviour
{
    [LabelText("是否可操作")]public bool isActive;
    [LabelText("左转按键")]public KeyCode rotateLeft;
    [LabelText("右转按键")]public KeyCode rotateRight;

    
    public void Update()
    {
        Rotate();
    }
    public void Rotate()
    {
        if (!isActive) return;
        if (Input.GetKeyDown(rotateLeft))
        {
            Debug.Log("sdsd");
            transform.Rotate(Vector3.forward, 45);
        }
        if (Input.GetKeyDown(rotateRight))
        {
            Debug.Log("sdsdsd");
            transform.Rotate(-Vector3.forward, 45);
        }
    }
}
