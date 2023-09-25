using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeAtkWeapon : Upgrade
{
    public UpgradeAtkWeapon()
    {
        this.name = "Increase 2 atk ";
    }

    public override void UpgradeWeapon(Weapon weapon, WeaponType weaponType)
    {
        float atk = weapon.GetAtk(weaponType);
        atk += 2; 
        weapon.SetAtk(weaponType,atk);
    }


}
