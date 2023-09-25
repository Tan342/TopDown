using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeAttack : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed = 5f;
    // Start is called before the first frame update
    Player player;
    MonsterMovemen monsterMovemen;
    bool isShoot = false;
    void Start()
    {
        player = FindObjectOfType<Player>();
        monsterMovemen = GetComponent<MonsterMovemen>();
        StartCoroutine("Shoot");
    }

    private void Update()
    {
        float dis = Vector3.Distance(transform.position, player.transform.position);
        if (dis <= monsterMovemen.getDistance() && !isShoot)
        {
            StartCoroutine("Shoot");
        }
    }

    IEnumerator Shoot()
    {
        isShoot = true;
        Vector3 difference = player.transform.position - transform.position;
        difference.y -= 1;
        difference.Normalize();

        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rigidbody2D = bullet.GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(difference * bulletSpeed, ForceMode2D.Impulse);
        bullet.GetComponent<EnemyBullet>().SetDamage(1);

        yield return new WaitForSeconds(5f);
        isShoot = false;
    }
}
