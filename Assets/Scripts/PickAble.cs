using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAble : MonoBehaviour
{
    public int scoreAmont = 1;
    public ParticleSystem pickPartical = null;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            scoreManager.score += scoreAmont;
            OnDisable();
            Destroy(gameObject); // The object to destroy.
        }
    }
    private void OnDisable() {
        pickPartical.Play();
    }
}
