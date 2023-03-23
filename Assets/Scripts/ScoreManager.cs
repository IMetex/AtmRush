using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;

    // UI menu
    public Text scoreGameOverText;
    public Text scoreWinText;
    void Update()
    {
        scoreText.text = score.ToString();  // Level star point 

        scoreGameOverText.text = score.ToString();  // Finish UI game over star point
        scoreWinText.text = score.ToString();       // Finish UI win star point
    }
}