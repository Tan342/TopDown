using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float maxHp = 3;
    [SerializeField] float exp = 2;
    [SerializeField] GameObject displayDamage;
    Animator animator;
    float currentHp;
    MonsterMovemen monsterMovemen;
    CapsuleCollider2D capsuleCollider2D;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        monsterMovemen = GetComponent<MonsterMovemen>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        player = FindObjectOfType<Player>();
        int l = player.GetComponent<Player>().GetLevel();
        maxHp = maxHp * l;
        exp = exp + l * 0.5f;
        currentHp = maxHp;
    }

    public void TakeDamage(float damage)
    {
        currentHp -= damage;
        animator.SetTrigger("Hit");
        DisplayDamage(damage);
        if (currentHp <= 0)
        {
            animator.SetTrigger("Dead");
            player.GetComponent<PlayerHealth>().addExp(exp);
            StartCoroutine("WaitForDestroy");
        }

    }

    void DisplayDamage(float damage)
    {
        Vector3 position = transform.position;
        position.y += 3;
        GameObject temp = Instantiate(displayDamage, position , Quaternion.identity);
        temp.GetComponentInChildren<DisplayDamage>().ChangeText(damage.ToString());
    }

    IEnumerator WaitForDestroy()
    {
        monsterMovemen.enabled = false;
        capsuleCollider2D.enabled = false;
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
