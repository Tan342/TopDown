using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Animator animator;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

        Move();
        
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        float moveSpeed = player.GetSpeed();
        float moveX = x * Time.deltaTime * moveSpeed;
        float moveY = y * Time.deltaTime * moveSpeed;
        transform.Translate(moveX, moveY, 0);


        if (x != 0 || y != 0)
        {
            animator.SetBool("Move", true);
        }
        else
        {
            animator.SetBool("Move", false);
        }
    }

   
}
