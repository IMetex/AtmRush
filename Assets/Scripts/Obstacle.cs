using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private GameObject _cashDestroyedParticle;

    private void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.CompareTag("Gate") && other.gameObject.tag == "Collect")
        {
            for (int i = 0; i < PlayerManager.Instance.collected.Count; i++)
            {
                if (PlayerManager.Instance.collected[i] == other.gameObject)
                {
                    /*var hitNormal = this.GetContact(0).normal;
                    var hitDot = Vector3.Dot(hitNormal, Vector3.forward);*/
                    
                    DestroyObject(other.gameObject, i);
                    StartCoroutine(MakeObjectsBigger());
                }
            }
        }
    }

    private void DestroyObject(GameObject other, int index)
    {
        int countList = PlayerManager.Instance.collected.Count;

        for (int i = index; i < countList; i++)
        {
            GameObject gameObject = PlayerManager.Instance.collected[i];

            if (i == PlayerManager.Instance.collected.Count - 1)
            {
                ParticalAnim(this.gameObject);
            }

            if (gameObject.CompareTag("Collect"))
            {
                StackManager.Instance.stackValue--;
                StackManager.Instance.stackValueText.text = StackManager.Instance.stackValue.ToString();
            }

            Destroy(gameObject);
        }

        PlayerManager.Instance.collected.RemoveRange(index, countList - index);
    }

    public IEnumerator MakeObjectsBigger()
    {
        Vector3 scale = Vector3.zero;
        scale = new Vector3(1, 1, 1);
        Vector3 doScale = scale * 1.2f;
        transform.DOScale(doScale, 0.06f).OnComplete(() =>
            transform.DOScale(scale, 0.06f));

        yield return new WaitForSeconds(0.02f);
    }

    private void ParticalAnim(GameObject obstacle)
    {
        Instantiate(_cashDestroyedParticle, obstacle.transform.position + new Vector3(0, 3.8f, 0f),
            Quaternion.identity);
    }
}