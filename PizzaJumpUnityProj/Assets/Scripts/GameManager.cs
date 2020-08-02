using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Pathfinding;
using TMPro;
public class GameManager : MonoBehaviour
{
    public SpriteRenderer backroundSprt;

    GameObject player;
    Color newColor;

    public Text scoreTxT;

  public  GridGraph grid;

    public bool gameOver = false;

    float multiplier = 0.00002f;

    public Button pauseBTN;

   public bool hasPressedPause = false;
    public Sprite pauseSprite, playSprite;

    public Camera mainCam;

    float nextTimeToScan = 20;

    void Awake()
    {
        player = GameObject.Find("Player");
        newColor = backroundSprt.color;

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    void Update()
    {
        //pause the game
        player.GetComponent<Player>().hasPressedPause = hasPressedPause;

        //update the score text
        scoreTxT.text ="SCORE: "+Mathf.RoundToInt( player.GetComponent<Player>().topScore).ToString();


        //adjust the backround color based on player position
        multiplier = player.transform.position.y/1000000;
        if (newColor.a <= 1)
        {
            newColor.a = player.transform.position.y / 200;
        }
         else if(newColor.g != 0)
        {
            newColor.g -= multiplier;
            newColor.a = 1;
        }
         if(newColor.g <=110)
        {
            newColor.r -= multiplier;
        }

         if(newColor.r <=100)
        {
            newColor.g += multiplier;

        }

        backroundSprt.color = newColor;

        //rescan the graph size for pathfinding
        if ( player.transform.position.y > AstarPath.active.data.gridGraph.center.y)
        {
            float playerPos = player.transform.position.y;
            Debug.LogError("S-a rescanat");
            AstarPath.active.data.gridGraph.center.y += 30;
            AstarPath.active.Scan(AstarPath.active.data.graphs);
            nextTimeToScan += 20;   
        }



        //UI for pause/play button
        if (hasPressedPause)
        {
            pauseBTN.GetComponent<Image>().sprite = playSprite;
            Time.timeScale = 0;
            mainCam.GetComponent<AudioListener>().enabled = false;
        }

        else
        {
            pauseBTN.GetComponent<Image>().sprite = pauseSprite;
            Time.timeScale = 1;
            mainCam.GetComponent<AudioListener>().enabled = true;

        }


    }

    public void BackBTN()
    {
        SceneManager.LoadScene(0);
    }

    public void PauseBTN()
    {
        if (!hasPressedPause)
            hasPressedPause = true;
        else
            hasPressedPause = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag =="Player")
        {
            Player player = other.collider.GetComponent<Player>();

        }
    }
}
