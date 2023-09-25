using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] TextMeshPro textMeshPro;
    
    private void Start() {
        //textMeshPro = GetComponent<TextMeshPro>();
    }
    
    public void ChangeText(string s)
    {
        textMeshPro.text = s;
    }

}
