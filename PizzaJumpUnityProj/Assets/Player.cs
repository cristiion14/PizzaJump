using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float maxHealth = 100f;
    float health;

    Rigidbody2D rb;
   public float movement = 0f;
    public float speed = 10f;
   public Vector3 positionTracker;

    public Transform edgeL, edgeR;
    public int iteratorLedge = 0;

  public  bool hasJumped = false;

    public float topScore = 0;



    public AudioClip hitSound;
    public AudioClip DeathSound;

    public AudioSource deathSoundAudioSource;

    //public Material dissolveMaterial;
    float dissolveMeeter = 1;

   public bool wasHit = false;
    public bool gameOver = false;

public    bool hasPressedPause = false;

    public GameObject playerDeathParticle;

    GameObject GM;
    CustomSampler sampler;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
        GM = GameObject.Find("GM");

    }

    void Update()
    {
        movement = Input.GetAxis("Horizontal") * speed;

        if (transform.position.y < (positionTracker.y - 10))
            Die(2);

        
            
        if (rb.velocity.y > 0 && transform.position.y > topScore)
            topScore = transform.position.y;

        if (wasHit)
        {
            dissolveMeeter -= Time.deltaTime;
     //       GetComponent<SpriteRenderer>().material = dissolveMaterial;
       //     GetComponent<SpriteRenderer>().material.SetFloat("_Fade", dissolveMeeter);
            Die(.5f);
        }
    }

    void FixedUpdate()
    {
       


        if (transform.position.x < -3.2f)
        {

            transform.position = new Vector3(3.2f, transform.position.y, 0);
        }
        else if (transform.position.x > 3.2f)
            transform.position = new Vector3(-3.2f, transform.position.y, 0);
    }

  public  void TakeDMG(float damage)
    {
        health -= damage;

        StartCoroutine(WaitForSeconds(2.5f));
        if (health <= 0)
        {
            EnemyDeath();
        }
    }

    int DeathSoundIterator = 0;

    /// <summary>
    /// Playes the death sound
    /// </summary>
    /// <returns></returns>
    IEnumerator DeathSoundEnum()
    {
       
        if (DeathSoundIterator == 0)
        {
            GetComponent<AudioSource>().clip = DeathSound;
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(1.3f);
            DeathSoundIterator = 1;
        }
    }
    int x = 0;

    void EnemyDeath()
    {
        Debug.LogError("HAIDEEEEE");
        WaitForSeconds(0.2f);

 
    }
   public void Die(float time)
    {


        if (x == 0 )
        {
            StartCoroutine(DeathSoundEnum());
            x = 1;
        }

        Destroy(deathSoundAudioSource,time);

        if (deathSoundAudioSource == null)
        {
            health = maxHealth;
            gameOver = true;

            //destroy all monsters
            GameObject[] monstersToBeDestroyed = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject monster in monstersToBeDestroyed)
            {
                Destroy(monster);
            }

            //SceneManager.LoadScene(2);
        }

        

    }
    /// <summary>
    /// Makes wasHit true in specifed time.
    /// Used for restarting game when hited
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    IEnumerator WaitForSeconds(float time)
    {

        yield return new WaitForSeconds(time);
        health = maxHealth;
        SceneManager.LoadScene(0);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == "Ledge" || other.collider.tag=="BoostLedge" || other.collider.tag == "DestructiveLedge")
        {
            positionTracker.y = other.collider.transform.position.y;
            iteratorLedge++;
            hasJumped = true;
        }

        if (other.collider.name == "lastPlatform")
        {
          
            List<GameObject> toBeDeleted = GM.GetComponent<LevelGenerator>().instantiatedPlatform;
            for (int i = 0; i < toBeDeleted.Count-1; i++)
            {
                toBeDeleted.Remove(toBeDeleted[i]);
                Destroy(toBeDeleted[i]);
            }

            //instantiate new ones
            GM.GetComponent<LevelGenerator>().InstantiatePlaftorms(100, transform.position);
        }
     
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Ledge")
            hasJumped = false;
    }
}
