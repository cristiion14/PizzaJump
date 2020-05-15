using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverGM : MonoBehaviour
{
    bool hasPressedRestart = false;
    public Text scoreTxT;
    int highScore = 0;
    int score = 0;
    GameObject player;
    public GameObject gameOverCanvas;
    public GameObject panel;
    void Awake()
    {
        player = GameObject.Find("Player");
        highScore = PlayerPrefs.GetInt("HIGHSCORE");
        gameOverCanvas.SetActive(false);
    }

    void DisableComponents()
    {
        //  Time.timeScale = 0;
        gameOverCanvas.SetActive(true);
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
        panel.SetActive(false);
        GetComponent<GameManager>().mainCam.GetComponent<AudioListener>().enabled = false;
    }

    void Update()
    {
        //if the game is finished
        if (player.GetComponent<Player>().gameOver)
        {
            //disable the unnecessary things
            //enable the game over canvas
            DisableComponents();

            //store the score
            score = Mathf.RoundToInt(player.GetComponent<Player>().topScore);

            //compare the values and assign the highscore to the maximum one
            if (score > highScore)
            {
                highScore = score;
                PlayerPrefs.SetInt("HIGHSCORE", highScore);
            }

            //update the text
            scoreTxT.text = "SCORE: " + score.ToString();

            //reload the scene
            if (Input.GetMouseButtonDown(0) || Input.touchCount>0)
                SceneManager.LoadScene(1);

        }



    }

}
