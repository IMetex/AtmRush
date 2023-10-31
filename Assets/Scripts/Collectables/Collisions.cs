using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collisions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            if (!PlayerManager.Instance.collected.Contains(other.gameObject))
            {
                other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
                other.gameObject.tag = "Collect";
                other.gameObject.AddComponent<Collisions>();
                other.gameObject.AddComponent<Rigidbody>();
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                StackManager.Instance.StackObject(other.gameObject, PlayerManager.Instance.collected.Count - 1);
            }
        }
    }
}