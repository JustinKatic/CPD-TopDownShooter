using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public Text Scoretext;

    public Text highscoreText;
    
    void Awake()
    {
        Scoretext = GetComponent<Text>();
        score = 0;
       
        highscoreText.text = "Highscore : " + PlayerPrefs.GetFloat("Highscore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Scoretext.text = "Zombie Kill Score: " + score;


        if (PlayerPrefs.GetFloat("Highscore") < score)
            PlayerPrefs.SetFloat("Highscore", score);
    }
}
