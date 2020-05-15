using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	//This is the enemy class
	
    float maxHealth = 100f;
  public  float health;

  public  Animator animCtrl;
    GameObject player;

   public GameObject monsterGFX;

    public GameObject enemyDeathParticle;
   public AudioClip enemyDeathSound;
    public AudioClip enemySound;
    void Start()
    {
        player = GameObject.Find("Player");

        health = maxHealth;
        
     //   animCtrl = GetComponentInChildren<Animator>();
    }

    
    void Update()
    {

       // GetComponent<AudioSource>().volume = 
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
            player.wasHit = true;
         //   player.TakeDMG(100);
            animCtrl.SetBool("IsTouching", true);

//            Instantiate(player.playerDeathParticle, player.transform.position, Quaternion.identity);
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
