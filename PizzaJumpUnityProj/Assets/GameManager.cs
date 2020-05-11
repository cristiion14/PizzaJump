using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    bool hasPressedPause = false;
    public Sprite pauseSprite, playSprite;

    void Awake()
    {
        player = GameObject.Find("Player");
        newColor = backroundSprt.color;

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    void Update()
    {

        scoreTxT.text ="SCORE: "+Mathf.RoundToInt( player.GetComponent<Player>().topScore).ToString();


        multiplier = player.transform.position.y/1000000;
        if (newColor.a <= 1)
        {
            newColor.a = player.transform.position.y / 200;
        }
         else if(newColor.g != 0)
        {
            newColor.g -= multiplier;
        }
        else if(newColor.g <=0)
        {
            newColor.r -= multiplier;
        }


        backroundSprt.color = newColor;

        //UI for pause/play button
        if (hasPressedPause)
        {
            pauseBTN.GetComponent<Image>().sprite = playSprite;
            Time.timeScale = 0;
            Camera.main.GetComponent<AudioListener>().enabled = false;
        }

        else
        {
            pauseBTN.GetComponent<Image>().sprite = pauseSprite;
            Time.timeScale = 1;
            Camera.main.GetComponent<AudioListener>().enabled = true;

        }


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
