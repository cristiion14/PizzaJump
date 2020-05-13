using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{

    public GameObject platformPrefab;
    public GameObject destructivePlatformPrefab;
    public GameObject boostPlatformPrefab;
    public GameObject monsterPrefab;

    GameObject newPlatform;
    GameObject instantiatedObj;

   public List<GameObject> addedEnemies = new List<GameObject>();
    GameObject instantiatedMonstr;

    int monsterInstantiated = 0;
    Vector2 playerLastPos =Vector2.zero;
    float nextTimeToSpawn = 10;
    void Update()
    {

        if (Time.time > nextTimeToSpawn)
        {
            StartCoroutine(InstantiateMonstr());
            nextTimeToSpawn += 10;
            Debug.LogError("MONSTRU IN");

            x = 0;
        }
        monsterInstantiated = GameObject.FindGameObjectsWithTag("Enemy").Length;

    }


    IEnumerator InstantiateMonstr()
    {
        yield return new WaitForSeconds(1);
        if (monsterInstantiated < 2)
        {
            addedEnemies.Add(Instantiate(monsterPrefab, new Vector2(Random.Range(-4f, 5f), GetComponentInParent<Player>().transform.position.y - Random.Range(10, 20)), Quaternion.identity));
            monsterInstantiated++;
        }
      
    }

    int x = 0;
    void OnTriggerEnter2D(Collider2D other)
    {
        /*
        //Instatiate new platform
        newPlatform = (GameObject)Instantiate(platformPrefab, new Vector2(Random.Range(-4, 4), 
            GetComponentInParent<Player>().transform.position.y + (3.5f + Random.Range(0.5f, 1f))), Quaternion.identity);

        if(other.tag=="Ledge")
            Destroy(other.gameObject);
            */

         playerLastPos = GetComponentInParent<Player>().transform.position;
      

        if (other.tag == "Ledge")
        {
         
                other.transform.position = new Vector2(Random.Range(-2.5f, 2.5f), GetComponentInParent<Player>().transform.position.y +
           (2f + Random.Range(0.5f, 1f)));

        }

         if (other.tag == "DestructiveLedge")
        {
     //       if (Random.Range(1, 20) == 5)
       //     {

         //       Debug.Log("Random");
           //     other.transform.position = new Vector2(Random.Range(-2.5f, 2.5f), GetComponentInParent<Player>().transform.position.y +
       //  (3.5f + Random.Range(0.5f, 1f)));
         //   }
           // else
            //{
                Debug.Log("ELSE");
                Destroy(other.gameObject);
                Instantiate(destructivePlatformPrefab, new Vector2(Random.Range(-2.5f, 2.5f),
                    GetComponentInParent<Player>().transform.position.y + 2f + Random.Range(0.5f, 1f)), Quaternion.identity);
            }
     
        //   instantiatedObj = other.gameObject;
        if (Random.Range(1, 20) == 5)
        {
          instantiatedObj=  Instantiate(boostPlatformPrefab, new Vector2(Random.Range(-2.5f, 2.5f),
             GetComponentInParent<Player>().transform.position.y + 2 + Random.Range(0.5f, 1f)), Quaternion.identity);

            if (x == 0)
            {
                Instantiate(destructivePlatformPrefab, new Vector2(Random.Range(-2.5f, 2.5f),
                 instantiatedObj.transform.position.y + 2 + Random.Range(0.5f, 2f)), Quaternion.identity);
                x = 1;
            }
            

        }
        if (other.tag == "BoostLedge")
            Destroy(other.gameObject);

    }
}
