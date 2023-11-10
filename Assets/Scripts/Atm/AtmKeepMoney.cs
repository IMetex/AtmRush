using System.Collections;
using DG.Tweening;
using Singleton;
using Stack;
using UnityEngine;

namespace Atm
{
    public class AtmKeepMoney : Singleton<AtmKeepMoney>
    {
        public IEnumerator ATMKeepMoney(GameObject other, int index)
        {
            if (index == 0)
                index = 1;

            if (index == StackLerpMovement.Instance.collected.Count - 1)
            {
                GameObject gameObject =
                    StackLerpMovement.Instance.collected[StackLerpMovement.Instance.collected.Count - 1];

                Vector3 scale = gameObject.transform.localScale;
                Vector3 doScale = scale * .5f;
                StackLerpMovement.Instance.collected.Remove(gameObject);
                gameObject.transform.DOScale(doScale, 0.02f).OnComplete(() =>
                    gameObject.transform.DOScale(scale, 0.02f)).OnComplete(() => { Destroy(gameObject); });
                yield return new WaitForSeconds(0.02f);
            }
            else
            {
                for (int i = StackLerpMovement.Instance.collected.Count - 1; i >= index; i--)
                {
                    GameObject gameObject = StackLerpMovement.Instance.collected[i];
                    Vector3 scale = gameObject.transform.localScale;
                    Vector3 doScale = scale * .5f;
                    StackLerpMovement.Instance.collected.Remove(gameObject);
                    gameObject.transform.DOScale(doScale, 0.3f).OnComplete(() =>
                        gameObject.transform.DOScale(scale, 0.3f)).OnComplete(() => { Destroy(gameObject); });
                    yield return new WaitForSeconds(0.02f);
                }
            }
        }
    }
}