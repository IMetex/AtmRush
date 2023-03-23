using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
 private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);

        if (other.gameObject.tag == "Player")
        {
            CountdownTimer countdownTimer = FindObjectOfType<CountdownTimer>();
            // GameOver scripts work gameover panel opening
            countdownTimer.GameOver();
        }
    }
}

