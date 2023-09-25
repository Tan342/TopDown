using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public class GraphicManager : MonoBehaviour
{
    [SerializeField] TMP_Dropdown dropdown;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("quality"))
        {
            dropdown.value = QualitySettings.GetQualityLevel();
            Save();
        }
        else
        {
            Load();
        }
        
    }

    public void ChangeQuality()
    {
        QualitySettings.SetQualityLevel(dropdown.value);
        Save();
    }

    void Save()
    {
        PlayerPrefs.SetInt("quality",dropdown.value);
    }

    void Load()
    {
        dropdown.value = PlayerPrefs.GetInt("quality");
        QualitySettings.SetQualityLevel(dropdown.value);
    }
    
}
