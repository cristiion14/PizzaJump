using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
public class PlatformDestroyer : MonoBehaviour
{
	//Responsible for destroying and creating platforms

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

    //Profiling
    CustomSampler sampler;
    GameObject GM;


    //platforms pos
    public int numberOfPlatforms = 100;
    public float levelWidth = 2.8f;
    public float minY = .2f;
    public float maxY = 1.5f;

    void Start()
    {
        GM = GameObject.Find("GM");
    }


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
    float offset = 0;
    void OnTriggerEnter2D(Collider2D other)
    {
      
        playerLastPos = GetComponentInParent<Player>().transform.position;

        //margin between the distances
        offset = other.transform.position.y - transform.position.y;

        //the position to instantiate at
        Vector2 posToInstantiate = new Vector2(Random.Range(-levelWidth, levelWidth),offset+ GetComponentInParent<Player>().transform.position.y);

        //Starting the profiling
        sampler = CustomSampler.Create("Collision Instantiating");
        sampler.Begin();

        if (other.tag == "Ledge")
                  other.transform.position = posToInstantiate;

        if (other.tag == "DestructiveLedge")
        {
            Debug.Log("ELSE");
            Destroy(other.gameObject);
            Instantiate(destructivePlatformPrefab, posToInstantiate, Quaternion.identity);
        }
        if (Random.Range(1, 50) == 5)
        {
            instantiatedObj = Instantiate(boostPlatformPrefab, posToInstantiate, Quaternion.identity);

            if (x == 0)
            {
                Instantiate(destructivePlatformPrefab, posToInstantiate, Quaternion.identity);
                x = 1;
            }
        }
        if (other.tag == "BoostLedge")
            Destroy(other.gameObject);

        //end zone of profiling
        sampler.End();

    }

}

