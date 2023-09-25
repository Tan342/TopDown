using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] WeaponType weaponType;
    [SerializeField] int amout = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponentInChildren<Weapon>().IncreaseAmmo(weaponType, amout);
            Destroy(gameObject);
        }
    }
}
