using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public GameObject starTextPanel;
    public GameObject timeTextPanel;
    public GameObject levelTextPanel;
    public bool isMovingStop = false;
    private void Start()
    {
        // Adding objects to destroy
        // countdownTimer.destroyAferGame.AddRange(GameObject.FindGameObjectsWithTag("Star"));

        starTextPanel.SetActive(true);
        timeTextPanel.SetActive(true);
    }

    // New Level Script
    public void OnTriggerEnter(Collider other)
    {
        CountdownTimer countdownTimer = FindObjectOfType<CountdownTimer>();
        // CountdownTimer script call 
        if (other.gameObject.tag == "Player" && countdownTimer.gameOver == false)
        {

            countdownTimer.winPanel.SetActive(true); // show the game over panel
            countdownTimer.gameOverPanel.SetActive(false); // not show the game over panel
            isMovingStop = true;
            // UI panel show deacttive
            starTextPanel.SetActive(false);
            timeTextPanel.SetActive(false);
            levelTextPanel.SetActive(false);

            // background mucis off netx level panel open
            countdownTimer.audoiSource.GetComponent<AudioSource>().enabled = false;

            // destroy gameobjets 
            /* foreach (GameObject allObjects in countdownTimer.destroyAferGame)
            {
                Destroy(allObjects);
            } */
        }
    }
}

