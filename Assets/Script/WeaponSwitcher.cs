using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;
    WeaponSound weaponSound;

    private void Start() {
        weaponSound = GetComponentInChildren<WeaponSound>();
    }

    private void Update()
    {
        int previousWeapon = currentWeapon;

        SetWeapon();

        if (previousWeapon != currentWeapon)
        {
            weaponSound.PlayLoadEffect();
            SetWeaponActive();
        }
    }

    void SetWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 2;
        }

    }

    public void SetWeaponActive()
    {
        int weaponIndex = 0;

        foreach (Transform weapon in transform)
        {
            if (weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }

    }
}
