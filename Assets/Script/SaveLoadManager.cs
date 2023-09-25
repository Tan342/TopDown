using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Weapon weapon;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("save") && PlayerPrefs.GetInt("save") == 1)
        {
            player.Load();
            weapon.Load();
        }
    }

    public void SaveGame()
    {
        player.Save();
        weapon.Save();
        PlayerPrefs.SetInt("save",1);
    }
}
