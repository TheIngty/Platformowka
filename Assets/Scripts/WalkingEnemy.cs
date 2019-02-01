using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemy: MonoBehaviour
{

    float dirX, moveSpeed = 1f;
    bool moveRight = true;
    public float left;
    public float right;

    void Update()
    {
        if (transform.position.x > right)
        {
            moveRight = false;
        }
        if (transform.position.x < left)
        {
            moveRight = true;
        }

        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }
    }
}