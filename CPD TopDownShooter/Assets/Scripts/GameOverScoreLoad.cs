using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOverScoreLoad : MonoBehaviour
{

    public Text Scoretext;
    public Text highscoreText;

    private void Awake()
    {
        highscoreText.text = "Highscore : " + PlayerPrefs.GetFloat("Highscore").ToString();
        Scoretext.text = "Score : " + PlayerPrefs.GetFloat("Score").ToString();
    }

}
