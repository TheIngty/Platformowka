using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    float dirX, moveSpeed = 3f;
    bool moveRight = true;
    public int left;
    public int right;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > right)
            moveRight = false;
        if (transform.position.x < left)
            moveRight = true;

        if (moveRight)
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        else
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
    }
}