using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using Unity.Profiling;
public class LevelGenerator : MonoBehaviour
{
    public GameObject platformPrefab, destructivePlat;
    public GameObject boostPlatformPrefab;
    public GameObject monsterPrefab;


    /// <summary>
    /// based on the height of the player
    /// </summary>
    int nextTimeToSpawnPlatform = 200;
   public List<GameObject> platforms = new List<GameObject>();


  public  GameObject player;
   public GameObject platformDestroyer; 

  public  List<GameObject> instantiatedPlatform = new List<GameObject>();
    public Transform firstPlatformPos;

     int numberOfPlatforms = 200;
    public float levelWidth = 2.8f;
    public float minY = .2f;
    public float maxY = 1.5f;

    public int nextTimeToSpawn = 10;

  
    int monsterInstantiated = 0;
    public List<GameObject> addedEnemies = new List<GameObject>();

    bool canDestroyPlat = false;

    int instantiatePosD = 1;
    Vector3 spawnPos = new Vector3();


    CustomSampler sampler;
    GameObject lastPlatform;
    Recorder profilerRec;

    GameObject platformToInstantiate;
    public void InstantiatePlaftorms(int numberOfPlatforms)
    {
        sampler = CustomSampler.Create("InstantiatingFunction");

        //begining of profiling
        sampler.Begin();

        //   InstantiatePlaftorms(numberOfPlatforms, Vector2.zero);
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            //Define the spawn position
            spawnPos.y += Random.Range(minY, maxY) + player.transform.position.y;
            spawnPos.x = Random.Range(-levelWidth, levelWidth);

            //pick a platform to instantiate
            if (Random.Range(1, 10) == 5)
                platformToInstantiate = destructivePlat;
            else if (Random.Range(10, 20) == 14)
                platformToInstantiate = boostPlatformPrefab;
            else
                platformToInstantiate = platformPrefab;

            //instantiate
           platforms.Add( Instantiate(platformToInstantiate, spawnPos, Quaternion.identity));
        }
        //end area of the profiler
        sampler.End();
    }

    void Start()
    {

        //Instantiate platforms
       InstantiatePlaftorms(numberOfPlatforms);
        
    }
       

    IEnumerator InstantiateMonstr()
    {
        yield return new WaitForSeconds(1);
        if (monsterInstantiated < 2)
        {
            //  addedEnemies.Add(Instantiate(monsterPrefab, new Vector2(Random.Range(-4f, 5f), player.GetComponent<Player>().transform.position.y - Random.Range(10, 20)), Quaternion.identity));
            GameObject enemy = Instantiate(monsterPrefab, new Vector2(Random.Range(-4f, 5f), player.GetComponent<Player>().transform.position.y - Random.Range(10, 20)), Quaternion.identity);
            monsterInstantiated++;
        }

    }

    void SpawnMonsters()
    {
        if (Time.time > nextTimeToSpawn)
        {
            StartCoroutine(InstantiateMonstr());
            nextTimeToSpawn += 10;
        }
        monsterInstantiated = GameObject.FindGameObjectsWithTag("Enemy").Length;

    }
    void Update()
    {

        if(player.transform.position.y %10 ==0)
        {
            Vector3 destructiveSpawnPos = new Vector3();
            destructiveSpawnPos.x = Random.Range(-levelWidth, levelWidth);
            destructiveSpawnPos.y += Random.Range(minY, maxY) + player.transform.position.y;

            Instantiate(destructivePlat,new Vector3(spawnPos.x, spawnPos.y, 0), Quaternion.identity);
        }
        SpawnMonsters();

    }

}
