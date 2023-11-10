using Manager;
using Stack;
using UnityEngine;

namespace Collectable
{
    public class Collision : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            // Money  Colllect
            if (other.gameObject.CompareTag("CollectableMoney"))
            {
                if (!StackLerpMovement.Instance.collected.Contains(other.gameObject))
                {
                    other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
                    other.gameObject.GetComponent<BoxCollider>().size = new Vector3(0.06f, 1f, 0.4f);
                    other.gameObject.tag = "Money";
                    other.gameObject.AddComponent<Collision>();
                    other.gameObject.AddComponent<Rigidbody>();
                    other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    StackManager.Instance.StackObject(other.gameObject, StackLerpMovement.Instance.collected.Count - 1);
                }
            }

            // Gold Collect
            if (other.gameObject.CompareTag("CollectableGold"))
            {
                if (!StackLerpMovement.Instance.collected.Contains(other.gameObject))
                {
                    other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
                    other.gameObject.GetComponent<BoxCollider>().size = new Vector3(1.2f, 0.95f, 0.4f);
                    other.gameObject.tag = "Gold";
                    other.gameObject.AddComponent<Collision>();
                    other.gameObject.AddComponent<Rigidbody>();
                    other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    StackManager.Instance.StackObject(other.gameObject, StackLerpMovement.Instance.collected.Count - 1);
                }
            }

            // Diaomond  Collect
            if (other.gameObject.CompareTag("CollectableDiamond"))
            {
                if (!StackLerpMovement.Instance.collected.Contains(other.gameObject))
                {
                    other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
                    other.gameObject.GetComponent<BoxCollider>().size = new Vector3(1f, 1f, 0.6f);
                    other.gameObject.tag = "Diamond";
                    other.gameObject.AddComponent<Collision>();
                    other.gameObject.AddComponent<Rigidbody>();
                    other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    StackManager.Instance.StackObject(other.gameObject, StackLerpMovement.Instance.collected.Count - 1);
                }
            }
        }
    }
}