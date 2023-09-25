using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    Upgrade upgrade;
    [SerializeField] TextMeshProUGUI textMeshPro;
    [SerializeField] Player player;
    [SerializeField] Weapon weapon;
    [SerializeField] WeaponType pistol;
    [SerializeField] WeaponType rifle;
    [SerializeField] WeaponType shotgun;
    int index;
    WeaponType weaponType;
    Canvas canvas;

    private void Start()
    {
        canvas = GetComponentInParent<Canvas>();
    }

    public void ChooseUpgrade(int index)
    {
        this.index = index;
        switch (index)
        {
            case 0:
                upgrade = new UpgradeHp();
                break;
            case 1:
                upgrade = new UpgradeAtkPlayer();
                break;
            case 2:
                upgrade = new UpgradeAtkWeapon();
                weaponType = pistol;
                break;
            case 3:
                upgrade = new UpgradeAtkWeapon();
                weaponType = rifle;
                break;
            case 4:
                upgrade = new UpgradeAtkWeapon();
                weaponType = shotgun;
                break;
        }
        ChangeName();
    }

    void ChangeName()
    {
        if (index == 2 || index == 3 || index == 4)
        {
            textMeshPro.text = upgrade.getName() + weaponType.ToString();
            return;
        }
        textMeshPro.text = upgrade.getName();
    }

    public void Upgrade()
    {
        if (index == 2 || index == 3 || index == 4)
        {
            upgrade.UpgradeWeapon(weapon, weaponType);
        }
        else
        {
            upgrade.UpgradePlayer(player);
        }
        canvas.enabled = false;
        Time.timeScale = 1;
    }
}
