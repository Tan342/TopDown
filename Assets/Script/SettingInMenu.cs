using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingInMenu : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    bool isDisplay = false;
    // Start is called before the first frame update
    void Start()
    {
        canvas.enabled = false;
    }

    public void Display()
    {
        isDisplay = !isDisplay;
        canvas.enabled = isDisplay;
    }
}
