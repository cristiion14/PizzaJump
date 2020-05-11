using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{

    public GameObject platformPrefab;
    public GameObject destructivePlatformPrefab;
    public GameObject boostPlatformPrefab;
    GameObject newPlatform;
    GameObject instantiatedObj;


    void OnTriggerEnter2D(Collider2D other)
    {
        /*
        //Instatiate new platform
        newPlatform = (GameObject)Instantiate(platformPrefab, new Vector2(Random.Range(-4, 4), 
            GetComponentInParent<Player>().transform.position.y + (3.5f + Random.Range(0.5f, 1f))), Quaternion.identity);

        if(other.tag=="Ledge")
            Destroy(other.gameObject);
            */
        if (other.tag == "Ledge")
        {
            if(Random.Range(1,20)==5)
            {

                Destroy(other.gameObject);
                Instantiate(destructivePlatformPrefab, new Vector2(Random.Range(-2.8f, 2.8f), 
                    GetComponentInParent<Player>().transform.position.y + 3.5f+Random.Range(0.5f, 1f)), Quaternion.identity);
            }
            else
                other.transform.position = new Vector2(Random.Range(-2.8f, 2.8f), GetComponentInParent<Player>().transform.position.y +
           (3.5f + Random.Range(0.5f, 1f)));

        }

        else if (other.tag == "DestructiveLedge")
        {
     //       if (Random.Range(1, 20) == 5)
       //     {

         //       Debug.Log("Random");
           //     other.transform.position = new Vector2(Random.Range(-2.8f, 2.8f), GetComponentInParent<Player>().transform.position.y +
       //  (3.5f + Random.Range(0.5f, 1f)));
         //   }
           // else
            //{
                Debug.Log("ELSE");
                Destroy(other.gameObject);
                Instantiate(destructivePlatformPrefab, new Vector2(Random.Range(-2.8f, 2.8f),
                    GetComponentInParent<Player>().transform.position.y + 3.5f + Random.Range(0.5f, 1f)), Quaternion.identity);
            }
        //}

        else if (other.tag == "BoostLedge")
        {
         //   instantiatedObj = other.gameObject;
            if (Random.Range(1, 20) == 5)
            {
                Destroy(instantiatedObj);
                    Instantiate(boostPlatformPrefab, new Vector2(Random.Range(-2.8f, 2.8f),
                     GetComponentInParent<Player>().transform.position.y + 3.5f + Random.Range(0.5f, 1f)), Quaternion.identity);
                Debug.LogError("A Intrat");

            }
            else
            {
                other.transform.position = new Vector2(Random.Range(-2.8f, 2.8f), GetComponentInParent<Player>().transform.position.y +
(3.5f + Random.Range(0.5f, 1f)));
            }
                    
            
        }

    }
}
