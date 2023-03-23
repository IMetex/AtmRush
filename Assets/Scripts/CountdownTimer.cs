using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CountdownTimer : MonoBehaviour
{
    // public List<GameObject> destroyAferGame = new List<GameObject>();
    public float timeLeft = 60.0f; // change this value to set the duration of the countdown
    private float timeElased = 0;

    [Header("UI Time Text Panel")]
    public Text timerText; //  UI Text object  in the Inspector
    public Text timerGameOverUIText; //  UI Text object  in the Inspector
    public Text timerWinUIText; //  UI Text object  in the Inspector

    [Header("UI Panel")]
    public GameObject gameOverPanel; // UI panel object in Inspector
    public GameObject winPanel; // UI panel object in Inspector
    public GameObject audoiSource;
    public bool gameOver = false;
    public ParticleSystem deathParticles;

    void Start()
    {
        //Adding objects to destroy 
        //destroyAferGame.AddRange(GameObject.FindGameObjectsWithTag("Star"));

        // Background Mucis
        audoiSource = GameObject.FindGameObjectWithTag("MainCamera");
    }
    void Update()
    {
        NextLevel nextLevel = FindObjectOfType<NextLevel>();

        if (!gameOver && nextLevel.isMovingStop == false)
        {
            // Time Left 
            timeLeft -= Time.deltaTime;
            timerText.text = Mathf.Round(timeLeft).ToString();

            audoiSource.GetComponent<AudioSource>().enabled = true;

            //  UI player life time show
            timeElased += Time.deltaTime;
            timerGameOverUIText.text = Mathf.Round(timeElased).ToString();
            timerWinUIText.text = Mathf.Round(timeElased).ToString();

            if (timeLeft <= 0)
            {
                GameOver();
                OnDisable();
            }
        }

    }
    public void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true); // show the game over panel
        winPanel.SetActive(false); // not show the game over panel

        // game over panel bakground mucis off
        audoiSource.GetComponent<AudioSource>().enabled = false;

        // DeadPartical Systtem
        deathParticles.Play();

        // UI panel show deacttive
        NextLevel nextLevel = FindObjectOfType<NextLevel>();
        nextLevel.starTextPanel.SetActive(false);
        nextLevel.timeTextPanel.SetActive(false);
        nextLevel.levelTextPanel.SetActive(false);

        // destroy gameobject list 
        /*  foreach (GameObject allObjects in destroyAferGame)
         {
             Destroy(allObjects);
         } */
    }

    void OnDisable()
    {
        deathParticles.Play();
    }

}