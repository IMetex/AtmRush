using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Atm
{
    public class AtmCounter : MonoBehaviour
    {
        public TMP_Text atmText;
        private int _count = 0;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Money"))
            {
                _count++;
            }
            else if (other.gameObject.CompareTag("Gold"))
            {
                _count += 2;
            }
            else if (other.gameObject.CompareTag("Diamond"))
            {
                _count += 3;
            }

            atmText.text = _count.ToString();
        }
    }
}