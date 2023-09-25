using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExpUI : MonoBehaviour
{
    Slider expSlider;
    TextMeshProUGUI expText;

    private void Start() {
        expSlider = GetComponentInChildren<Slider>();
        expText = GetComponentInChildren<TextMeshProUGUI>();
    }
    
    public void displayExp(float current, float max, int level)
    {
        expSlider.value = current / max;
        expText.text = "Lv." + level.ToString();
    }

}
