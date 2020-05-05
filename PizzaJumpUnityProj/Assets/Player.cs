using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    float movement = 0f;
    public float speed = 10f;
   public Vector3 positionTracker;

    public int iteratorLedge = 0;

  public  bool hasJumped = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement = Input.GetAxis("Horizontal") * speed;

        if (transform.position.y < (positionTracker.y - 3))
            SceneManager.LoadScene(0);

            
    }

    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == "Ledge")
        {
            positionTracker.y = other.collider.transform.position.y;
            iteratorLedge++;
            hasJumped = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Ledge")
            hasJumped = false;
    }
}
