using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Singleton;
using Stack;
using UnityEngine;

namespace Manager
{
    public class StackManager : Singleton<StackManager>
    {
        public void StackObject(GameObject obj, int index)
        {
            ScoreManager.Instance.ScoreValue++;
            ScoreManager.Instance._scoreText.text = ScoreManager.Instance.ScoreValue.ToString();
            obj.gameObject.transform.parent = transform;
            Vector3 newPosition = StackLerpMovement.Instance.collected[index].transform.localPosition;

            if (index == 0)
            {
                newPosition.z = 1f;
            }

            newPosition.z += 1f;
            newPosition.y = 0.3f;

            obj.transform.localPosition = newPosition;
            StackLerpMovement.Instance.collected.Add(obj);
            StartCoroutine(MakeObjectBigger());
        }

        public IEnumerator MakeObjectBigger()
        {
            for (int i = StackLerpMovement.Instance.collected.Count - 1; i >= 1; i--)
            {
                int index = i;

                if (StackLerpMovement.Instance.collected[index].gameObject.CompareTag("Money"))
                {
                    DOScaleObject(i);
                    yield return new WaitForSeconds(0.02f);
                }
                else if (StackLerpMovement.Instance.collected[index].gameObject.CompareTag("Gold"))
                {
                    DOScaleObject(i);
                    yield return new WaitForSeconds(0.02f);
                }
                else if (StackLerpMovement.Instance.collected[index].gameObject.CompareTag("Diamond"))
                {
                    DOScaleObject(i);
                    yield return new WaitForSeconds(0.02f);
                }
            }
        }

        public void DOScaleObject(int index)
        {
            Vector3 scale = new Vector3(1, 1, 1);
            Vector3 doScale = scale * 1.5f;
            StackLerpMovement.Instance.collected[index].transform.DOScale(doScale, 0.06f).OnComplete(() =>
                StackLerpMovement.Instance.collected[index].transform.DOScale(scale, 0.06f));
        }
    }
}