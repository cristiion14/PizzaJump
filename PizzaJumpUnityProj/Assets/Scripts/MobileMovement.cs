using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileMovement : MonoBehaviour
{
    float dirX, dirY = 0f;
    Player player;
    Rigidbody2D rb;

    bool isOnMobile = false;
    void Start()
    {
        player = GetComponent<Player>();
        rb = player.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //velocity vector
        dirX = Input.acceleration.x * player.speed; ;
    }

    void FixedUpdate()
    {
        //left -right accelerometer movement
        if (dirX!=0)
        {
            Vector2 velocity = rb.velocity;
            velocity.x = dirX;
            rb.velocity = velocity;
        }
        //keyboard movement for testing
        else
        {
            Vector2 velocity = rb.velocity;
            velocity.x = player.movement;
              rb.velocity = velocity;
        }

    }
}
