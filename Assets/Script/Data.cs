using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Data
{
    // Player
    float currentHp = 10;
    float maxHp = 10;
    float atk = 1;
    float speed = 5;
    int level = 1;
    float currentExp = 0;
    float maxExp = 10;

    // Monster 1
    float maxHp_M1 = 3;
    float exp_M1 = 2;

    // Monster 2
    float maxHp_M2 = 3;
    float exp_M2 = 2;

    //Weapon
    [SerializeField] WeaponSlot[] weaponSlots;

    [System.Serializable]
    class WeaponSlot
    {
        public WeaponType weaponType;
        public int ammoAmount;
        public float atk;
    }
}
