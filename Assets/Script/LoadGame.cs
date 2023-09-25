using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    public void LoadNewGame()
    {
        PlayerPrefs.SetInt("save",0);
        SceneManager.LoadScene(1);
    }

    public void LoadSaveGame()
    {
        SceneManager.LoadScene(1);
    }
    
}
