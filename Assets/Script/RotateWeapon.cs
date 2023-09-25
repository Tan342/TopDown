using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWeapon : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();

    }

    private void Rotate()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float x = difference.x;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + 3);

        if (rotation_z < -90 || rotation_z > 90)
        {
            transform.rotation = Quaternion.Euler(180, 0, -rotation_z + 3);
        }

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
