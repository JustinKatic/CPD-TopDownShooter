using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score;

    public Text Scoretext;

    public Text highscoreText;

    public GameObject player;

    float highScore;

    void Awake()
    {
        Scoretext = GetComponent<Text>();
        score = 0;

        highscoreText.text = "Highscore : " + PlayerPrefs.GetFloat("Highscore").ToString();

        highScore = PlayerPrefs.GetFloat("Highscore");
    }

    // Update is called once per frame
    void Update()
    {
        Scoretext.text = "Zombie Kill Score: " + score;


        if (highScore < score)
            PlayerPrefs.SetFloat("Highscore", score);

        if (player.GetComponent<PlayerHealthManager>().currentHealth <= 0)
            PlayerPrefs.SetFloat("Score", score);

    }
}
