using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float maxHealth = 100f;
  public  float health;

  public  Animator animCtrl;

    void Start()
    {
        health = maxHealth;
     //   animCtrl = GetComponentInChildren<Animator>();
    }

    public void TakeDmg(int damage)
    {
        health -= damage;

        if (health <= 0)
            Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == "Player")
        {
            Player player = other.collider.GetComponent<Player>();
            player.TakeDMG(10);
            animCtrl.SetBool("IsTouching", true);

        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            animCtrl.SetBool("IsTouching", false);
        }
    }
}
