using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButton : MonoBehaviour
{
    Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        if(PlayerPrefs.HasKey("save") && PlayerPrefs.GetInt("save") == 1)
        {
            canvas.enabled = true;
        }
        else
        {
            canvas.enabled = false;
        }
    }

}
