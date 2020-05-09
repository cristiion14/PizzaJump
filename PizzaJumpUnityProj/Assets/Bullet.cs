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
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");


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

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Enemy")
        {
            Enemy enemy = other.transform.GetComponent<Enemy>();
            DoHitEffect(enemy.transform.position, transform.up);
            hasHit = true;

            enemy.TakeDmg(100);
            Destroy(gameObject);
        }
        else
            transform.GetComponent<PolygonCollider2D>().isTrigger = true;
    }
    void OnCollisionExit2D(Collision2D other)
    {
    //    hasHit = false;
        transform.GetComponent<PolygonCollider2D>().isTrigger = false;
    }
}
