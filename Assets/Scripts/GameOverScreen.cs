using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // you have to specifically import UI to use Text

public class GameOverScreen : MonoBehaviour
/*
Loads the Game Over Screen. 
*/
{
    public GameObject currentScore;
    private Text currentScoreText;

    void Start() {
        currentScoreText = currentScore.GetComponent<Text>();  // get the score from the score GameObject
        currentScoreText.text = PlayerPrefs.GetString("currentScore");
    }
    public Text pointsText;
    public void Setup(int score) 
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " POINTS";
    }
}
