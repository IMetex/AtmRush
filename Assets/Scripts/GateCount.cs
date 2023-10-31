using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GateCount : MonoBehaviour
{
    public TMP_Text gateValue;
    private int count = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collect")
        {
            count++;
        }

        gateValue.text = count.ToString();
    }
}