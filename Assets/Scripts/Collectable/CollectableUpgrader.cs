using System.Collections;
using DG.Tweening;
using Manager;
using Singleton;
using UnityEngine;

namespace Collectable
{
    public class CollectableUpgrader : Singleton<CollectableUpgrader>
    {
        [SerializeField] private Mesh goldMesh, diamondMesh;
        [SerializeField] private Material goldMaterial, diamondMaterial;

        private void MakeObjectBigger(GameObject obj)
        {
            Vector3 scale = obj.transform.localScale;
            Vector3 doScale = scale * 1.5f;

            obj.transform.DOScale(doScale, 0.06f).OnComplete(() =>
                obj.transform.DOScale(scale, 0.06f));
        }

        public IEnumerator Upgradedobject(GameObject obj)
        {
            if (obj.CompareTag("Money"))
            {
                ScoreManager.Instance.ScoreValue++;
                ScoreManager.Instance._scoreText.text = ScoreManager.Instance.ScoreValue.ToString();
                obj.tag = "Gold";
                obj.GetComponent<MeshFilter>().mesh = goldMesh;
                obj.GetComponent<MeshRenderer>().material = goldMaterial;
                obj.GetComponent<BoxCollider>().size = new Vector3(1.2f, 0.9f, 0.4f);
                obj.transform.rotation = Quaternion.Euler(new Vector3(-90, 0, 0));
                obj.transform.localScale = new Vector3(1, 1, 1);

                MakeObjectBigger(obj);
                yield return new WaitForSeconds(0.02f);
            }
            else if (obj.CompareTag("Gold") || obj.CompareTag("Diamond"))
            {
                ScoreManager.Instance.ScoreValue += 2;
                ScoreManager.Instance._scoreText.text = ScoreManager.Instance.ScoreValue.ToString();
                obj.tag = "Diamond";
                obj.GetComponent<MeshFilter>().mesh = diamondMesh;
                obj.GetComponent<MeshRenderer>().material = diamondMaterial;
                obj.GetComponent<BoxCollider>().size = new Vector3(1f, 1f, 0.6f);
                obj.transform.rotation = Quaternion.Euler(new Vector3(-90, 0, 0));
                obj.transform.localScale = new Vector3(1, 1, 1);

                MakeObjectBigger(obj);
                yield return new WaitForSeconds(0.02f);
            }
        }
    }
}