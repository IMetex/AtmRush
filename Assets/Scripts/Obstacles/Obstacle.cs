using Atm;
using Stack;
using UnityEngine;

namespace Obstacles
{
    public class Obstacle : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (this.gameObject.CompareTag("Spine"))
            {
                if (other.CompareTag("Money") || other.CompareTag("Gold") || other.CompareTag("Diamond"))
                {
                    for (int i = 1; i < StackLerpMovement.Instance.collected.Count - 1; i++)
                    {
                        if (StackLerpMovement.Instance.collected[i] == other.gameObject)
                        {
                            DestroyObjects.Instance.DestroyMoney(other.gameObject, i, this.gameObject);
                            break;
                        }
                    }
                }
            }

            if (this.gameObject.CompareTag("ATM"))
            {
                for (int i = 1; i < StackLerpMovement.Instance.collected.Count - 1; i++)
                {
                    if (StackLerpMovement.Instance.collected[i] == other.gameObject)
                    {
                        StartCoroutine(AtmKeepMoney.Instance.ATMKeepMoney(other.gameObject, i));
                        break;
                    }
                }
            }

            if (this.gameObject.CompareTag("Card"))
            {
                if (other.CompareTag("Money") || other.CompareTag("Gold") || other.CompareTag("Diamond"))
                {
                    for (int i = 0; i < StackLerpMovement.Instance.collected.Count - 1; i++)
                    {
                        if (StackLerpMovement.Instance.collected[i] == other.gameObject)
                        {
                            Card.Instance.DistributeCollectibles(this.gameObject, i, this.gameObject);
                            break;
                        }
                    }
                }
            }
        }
    }
}