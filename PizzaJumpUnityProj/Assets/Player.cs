using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float maxHealth = 100f;
    float health;

    Rigidbody2D rb;
    float movement = 0f;
    public float speed = 10f;
   public Vector3 positionTracker;

    public Transform edgeL, edgeR;
    public int iteratorLedge = 0;

  public  bool hasJumped = false;

   public float getHealth()
    {
        return health;
    }

    public void setHealth(float newHealth)
    {
        health = newHealth;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
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


        if (transform.position.x < -3)
        {
            Vector3 destination = edgeR.position = new Vector3(0, transform.position.y, 0);
            Vector3 posOffset = destination -transform.position;

            transform.position = destination + posOffset;
        }
        else if (transform.position.x > 3)
            transform.position = new Vector3(-3, transform.position.y, 0);
    }

  public  void TakeDMG(float damage)
    {
        health -= damage;

        if (health <= 0)
            Die();
    }

    void Die()
    {
        health = maxHealth;
        SceneManager.LoadScene(0);
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
