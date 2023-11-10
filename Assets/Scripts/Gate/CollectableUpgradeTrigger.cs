using Collectable;
using UnityEngine;

namespace Gate
{
    public class CollectableUpgradeTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Money" || other.gameObject.tag == "Gold" || other.gameObject.tag == "Diamond")
            {
                StartCoroutine(CollectableUpgrader.Instance.Upgradedobject(other.gameObject));
            }
        }
    }
}