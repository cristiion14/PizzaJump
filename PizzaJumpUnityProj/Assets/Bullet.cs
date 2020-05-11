using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    float speed =15f;
    public GameObject impactEffect;

    bool hasHit = false;
    float timer = 5;

    GameObject player;
    GameObject GM;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        GM = GameObject.Find("GM");

        rb.velocity = (player.GetComponent<PlayerShoot>().direction - transform.position).normalized * speed ;
        //rb.AddForce(player.GetComponent<PlayerShoot>().direction, ForceMode2D.Impulse);

    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && !hasHit)
        {
            Destroy(gameObject);
            timer = 5;
        }
    }

        void DoHitEffect(Vector3 _pos, Vector3 _normal)
    {
        GameObject _hitEffect = Instantiate(impactEffect, _pos, Quaternion.LookRotation(_normal));
        Destroy(_hitEffect, 2f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Enemy enemy = other.transform.GetComponent<Enemy>();


            //disable enemy ai
            enemy.GetComponent<AI>().enabled = false;

            //do hit effect
        //    DoHitEffect(enemy.transform.position, transform.up);
            GM.GetComponentInChildren<DissolveShader>().isDissolving = true;

            //stop enemy sound
            enemy.GetComponentInChildren<AudioSource>().Stop();
            
            //play enemy death sound
            enemy.GetComponent<AudioSource>().Play();
            hasHit = true;

            //destroy bullet and enemy
            Destroy(other.gameObject, .5f);
            Destroy(gameObject,.1f);
        }
        else
            transform.GetComponent<PolygonCollider2D>().isTrigger = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
      //      Enemy enemy = other.transform.GetComponent<Enemy>();
        //    enemy.GetComponentInChildren<AudioSource>().clip = enemy.enemySound;
          //  enemy.GetComponentInChildren<AudioSource>().Play();
            //    hasHit = false;
            transform.GetComponent<PolygonCollider2D>().isTrigger = false;
        }
    }
}
