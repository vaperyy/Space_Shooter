using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // you have to specifically import UI to use Text

public class GameOverScreen : MonoBehaviour
{
    public Text pointsText;
    public void Setup(int score) 
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " POINTS";
    }
}
