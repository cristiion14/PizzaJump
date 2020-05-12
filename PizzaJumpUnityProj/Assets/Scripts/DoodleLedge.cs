using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoodleLedge : MonoBehaviour
{
    public float jumpForce = 10f;
    Vector3 newPos = new Vector3(13, 13, 0);
    Vector3 APointAnim = Vector3.zero;
    Vector3 BPointAnim = Vector3.zero;

   public AudioClip boostLedgeSound;
    public AudioClip ledgeSound;

    float movement = 3;
    void Awake()
    {
        if (gameObject.tag == "DestructiveLedge" && GetComponent<Animator>() != null)
            GetComponent<Animator>().enabled = false;

        if (gameObject.tag == "DestructiveLedge")
        {
            APointAnim = new Vector2(-3, gameObject.transform.position.y);
            BPointAnim = new Vector2(3, gameObject.transform.position.y);

            newPos = APointAnim;
        }
    }

    void Update()
    {
        DestructiveLedgeMovement();

    }

    void DestructiveLedgeMovement()
    {
        if (gameObject.tag == "DestructiveLedge")
        {

            APointAnim = new Vector2(-3, gameObject.transform.position.y);
            BPointAnim = new Vector2(3, gameObject.transform.position.y);


            float distance = (transform.position - APointAnim).sqrMagnitude;
            if (distance <= 1)
                newPos = BPointAnim;

            float distance2 = (transform.position - BPointAnim).sqrMagnitude;
            if (distance2 <= 1)
                newPos = APointAnim;
                
            transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime);
                
        }
    }
    int x = 0;

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.collider.tag == "Player")
        {
                Rigidbody2D rb = other.collider.GetComponent<Rigidbody2D>();
            

                //check to see if the obj is coming from top or bottom
                if (other.relativeVelocity.y <= 0f)
            {
                GetComponent<AudioSource>().Play();


                if (gameObject.tag=="BoostLedge")
                {
                    rb.AddForce(Vector2.up * 1900);
                }

                if (gameObject.tag == "DestructiveLedge" && GetComponent<Animator>() != null)
                {
                    GetComponent<Animator>().enabled = true;
                    Destroy(gameObject, 1);

                }
                
                //BOUNCY

                //get the rigid body of the collided obj

                if (rb != null)
                {
                    //modify the velocity of the rb
                    /*
                    Vector2 velocity = rb.velocity;
                    velocity.y = jumpForce;
                    rb.velocity = velocity;
                    */
                    rb.AddForce(Vector3.up *1200);
                }
            }
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "DestructiveLedge" && GetComponent<Animator>() != null)
        {
          //  GetComponent<Animator>().enabled = false;
            //other.collider.isTrigger = false;
        }
    }
    }
