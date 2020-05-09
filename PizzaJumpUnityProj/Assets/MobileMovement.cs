using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileMovement : MonoBehaviour
{
    float dirX, dirY = 0f;
    Player player;
    Rigidbody rb;
    void Start()
    {
        player = GetComponent<Player>();
        rb = player.GetComponent<Rigidbody>();
    }
    void Update()
    {
        dirX = Input.acceleration.x ;
    }

    void FixedUpdate()
    {
        player.transform.position += new Vector3(dirX, 0, 0)*player.speed * Time.deltaTime;
    }
}
