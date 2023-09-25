using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Upgrade
{
    protected string name;
    public string getName()
    {
        return name;
    }
    
    public virtual void UpgradePlayer(Player player){}
    public virtual void UpgradeWeapon(Weapon weapon, WeaponType weaponType){}
}
