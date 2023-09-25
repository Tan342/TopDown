using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovemen : MonoBehaviour
{
    [SerializeField] float monsterSpeed = 5f;
    [SerializeField] float distance = 5f;
    Movement player;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Movement>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Move();
        }
    }

    public float getDistance()
    {
        return distance;
    }

    void Move()
    {
        float dis = Vector3.Distance(transform.position, player.transform.position);
        if (dis > distance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, monsterSpeed * Time.deltaTime);
        }

        float x = player.transform.position.x - transform.position.x;
        if (x > 0)
        {
            animator.SetFloat("X", 1);
        }
        else if (x < 0)
        {
            animator.SetFloat("X", -1);
        }
    }
}
