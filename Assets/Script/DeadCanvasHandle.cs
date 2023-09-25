using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadCanvasHandle : MonoBehaviour
{
    Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponentInChildren<Canvas>();
        canvas.enabled = false;
    }

    public void display()
    {
        canvas.enabled = true;
    }
}
