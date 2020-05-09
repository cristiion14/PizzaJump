using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileMovement : MonoBehaviour
{
    float dirX, dirY = 0f;
    Player player;
    Rigidbody2D rb;
    void Start()
    {
        player = GetComponent<Player>();
        rb = player.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        dirX = Input.acceleration.x * player.speed; ;
    }

    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = dirX;
        rb.velocity = velocity;
    }
}
