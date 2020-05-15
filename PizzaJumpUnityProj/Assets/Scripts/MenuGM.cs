using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuGM : MonoBehaviour
{
    public Material dissolveTxt;
    float fade = 1;
    bool hasPressedStart = false;
    bool canStartGame = false;

    public int highScore;
    public Text highScoreTxT;
    void Awake()
    {
        dissolveTxt.SetFloat("_Fade", 1);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            hasPressedStart = true;

        if (hasPressedStart &&!canStartGame)
        {
            fade -= Time.deltaTime;

       
            
            if(fade<=0)
            {
               // fade = 1;
                hasPressedStart = false;
                canStartGame = true;
            }
        }
        dissolveTxt.SetFloat("_Fade", fade);
        highScore = PlayerPrefs.GetInt("HIGHSCORE");
        highScoreTxT.text ="HIGHSCORE "+ highScore.ToString();
        if (canStartGame)
            StartCoroutine(StartGame(.5f));
    }

    IEnumerator StartGame(float s)
    {
        yield return new WaitForSeconds(s);
        SceneManager.LoadScene(1);

    }

}
