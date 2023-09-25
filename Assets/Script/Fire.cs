using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Fire : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 100f;
    [SerializeField] float timeMuzzle = 0.5f;
    [SerializeField] float shootDelay = 0.5f;
    [SerializeField] WeaponType weaponType;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] SpriteRenderer muzzle;
    [SerializeField] TextMeshProUGUI ammoAmount;
    bool isShoot = false;
    Weapon weapon;
    Player player;
    WeaponSound weaponSound;

    private void OnEnable()
    {
        isShoot = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        muzzle.enabled = false;
        weapon = GetComponentInParent<Weapon>();
        player = GetComponentInParent<Player>();
        weaponSound = GetComponentInParent<WeaponSound>();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayAmmo();
        if (Input.GetButton("Fire1") && !isShoot)
        {
            StartCoroutine("Shoot");
        }
    }

    void DisplayAmmo()
    {
        ammoAmount.text = weapon.GetCurrentAmmo(weaponType).ToString();
    }

    IEnumerator Shoot()
    {
        isShoot = true;
        if (weapon.GetCurrentAmmo(weaponType) > 0)
        {
            FireBullet();
        }
        yield return new WaitForSeconds(shootDelay);
        isShoot = false;
    }

    void FireBullet()
    {
        foreach (Transform slot in transform)
        {
            GameObject bullet = Instantiate(bulletPrefab, slot.position, Quaternion.identity);
            Rigidbody2D rigidbody2D = bullet.GetComponent<Rigidbody2D>();
            rigidbody2D.AddRelativeForce(transform.right * bulletSpeed, ForceMode2D.Impulse);
            float damage = 0.7f * weapon.GetAtk(weaponType) + 0.3f * player.GetAtk();
            bullet.GetComponent<Bullet>().SetDamage(damage);
        }
        weaponSound.PlayShootEffect();
        StartCoroutine("Muzzle");
        weapon.ReduceAmmo(weaponType);

    }

    IEnumerator Muzzle()
    {
        muzzle.enabled = true;
        yield return new WaitForSeconds(timeMuzzle);
        muzzle.enabled = false;
    }
}
