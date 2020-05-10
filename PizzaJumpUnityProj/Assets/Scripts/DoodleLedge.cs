using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoodleLedge : MonoBehaviour
{
    public float jumpForce = 10f;
    Vector2 newPos = new Vector2(13, 13);
    Vector2 APointAnim = Vector2.zero;
    Vector2 BPointAnim = Vector2.zero;

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


            if (Vector2.Distance(transform.position, APointAnim)<.5f)
                newPos = BPointAnim;

            if (Vector2.Distance(transform.position, BPointAnim) < .5f)
                newPos = APointAnim;





            transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime);
                
        }
    }
    int x = 0;

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.collider.tag == "Player")
        {
            

                //check to see if the obj is coming from top or bottom
                if (other.relativeVelocity.y <= 0f)
            {
                GetComponent<AudioSource>().Play();


                if (gameObject.tag=="BoostLedge")
                {
     
                }

                if (gameObject.tag == "DestructiveLedge" && GetComponent<Animator>() != null)
                {
               
                    Destroy(gameObject, 1);

                }
                
                //BOUNCY

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

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "DestructiveLedge" && GetComponent<Animator>() != null)
        {
          //  GetComponent<Animator>().enabled = false;
            //other.collider.isTrigger = false;
        }
    }
    }
