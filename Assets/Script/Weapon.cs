using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] WeaponSlot[] weaponSlots;
    WeaponSwitcher weaponSwitcher;

    [System.Serializable]
    class WeaponSlot
    {
        public WeaponType weaponType;
        public int ammoAmount;
        public float atk;
    }

    // Start is called before the first frame update
    void Start()
    {
        weaponSwitcher = GetComponent<WeaponSwitcher>();
    }

    public void Save()
    {
        int i = 0;
        foreach (WeaponSlot w in weaponSlots)
        {
            PlayerPrefs.SetInt("wpAmmo" + i, w.ammoAmount);
            PlayerPrefs.SetFloat("wpAtk" + i, w.atk);
            i++;
        }
    }

    public void Load()
    {
        int i = 0;
        foreach (WeaponSlot w in weaponSlots)
        {
            w.ammoAmount = PlayerPrefs.GetInt("wpAmmo" + i);
            w.atk = PlayerPrefs.GetFloat("wpAtk" + i);
            i++;
        }
    }

    public void ReduceAmmo(WeaponType weaponType)
    {
        WeaponSlot weapon = GetWeaponSlot(weaponType);
        if (weapon.weaponType.ToString() == "pistol")
        {
            return;
        }
        weapon.ammoAmount--;
    }

    public void IncreaseAmmo(WeaponType weaponType, int amout)
    {
        GetWeaponSlot(weaponType).ammoAmount += amout;
    }

    public int GetCurrentAmmo(WeaponType weaponType)
    {
        return GetWeaponSlot(weaponType).ammoAmount;
    }

    public float GetAtk(WeaponType weaponType)
    {
        return GetWeaponSlot(weaponType).atk;
    }

    public void SetAtk(WeaponType weaponType, float amout)
    {
        GetWeaponSlot(weaponType).atk = amout;
    }

    WeaponSlot GetWeaponSlot(WeaponType weaponType)
    {
        foreach (WeaponSlot slot in weaponSlots)
        {
            if (slot.weaponType == weaponType)
            {
                return slot;
            }
        }
        return null;
    }

}
