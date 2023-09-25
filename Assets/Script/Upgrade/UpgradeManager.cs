using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    UpgradeButton[] upgradeButton;
    Canvas canvas;
    int buttonAmount;
    List<int> upgradeList = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        upgradeButton = GetComponentsInChildren<UpgradeButton>();
        canvas = GetComponentInChildren<Canvas>();
        canvas.enabled = false;
        buttonAmount = upgradeButton.Length;
    }

    public void DisplayUpgrade()
    {
        GetRandom();
        int i = 0;
        foreach (UpgradeButton button in upgradeButton)
        {
            button.ChooseUpgrade(upgradeList[i]);
            i++;
        }
        upgradeList.Clear();
        canvas.enabled = true;
        Time.timeScale = 0;
        
    }

    void GetRandom()
    {
        for (int i = 0; i < buttonAmount; i++)
        {
            int temp = 0;
            do
            {
                temp = Random.Range(0,5);
            } while (Check(temp));
            upgradeList.Add(temp);
        }
    }

    bool Check(int index)
    {
        foreach (int a in upgradeList)
        {
            if (a == index)
            {
                return true;
            }
        }
        return false;
    }
}
