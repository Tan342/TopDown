using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HpUI : MonoBehaviour
{
    Slider hpSlider;
    TextMeshProUGUI hpText;

    private void Start() {
        hpSlider = GetComponentInChildren<Slider>();
        hpText = GetComponentInChildren<TextMeshProUGUI>();
    }
    
    public void displayHp(float current, float max)
    {
        hpSlider.value = current / max;
        hpText.text = current.ToString() + "/" + max.ToString();
    }
}
