using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoodleLedge : MonoBehaviour
{
    public float jumpForce = 10f;
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            //check to see if the obj is coming from top or bottom
            if (other.relativeVelocity.y <= 0f)
            {
                //get the rigid body of the collided obj
                Rigidbody2D rb = other.collider.GetComponent<Rigidbody2D>();

                if (rb != null)
                {
                    //modify the velocity of the rb
                    Vector2 velocity = rb.velocity;
                    velocity.y = jumpForce;
                    rb.velocity = velocity;
                }
            }
        }
    }
}
