using DG.Tweening;
using Manager;
using Singleton;
using Stack;
using UnityEngine;

namespace Obstacles
{
    public class Card : Singleton<Card>
    {
        private void Start()
        {
            transform.DOMoveX(-3f, 1f)
                .From(3f)
                .SetEase(Ease.Linear)
                .SetLoops(-1, LoopType.Yoyo);
        }

        public void DistributeCollectibles(GameObject other, int index, GameObject obstacle)
        {
            if (index == 0)
            {
                index = 1;
            }

            for (int i = StackLerpMovement.Instance.collected.Count - 1; i > index; i--)
            {
                GameObject gameObject = StackLerpMovement.Instance.collected[i];
                StackLerpMovement.Instance.collected.Remove(gameObject);
                gameObject.GetComponent<BoxCollider>().isTrigger = true;
                gameObject.transform.parent = null;

                Vector3 target = new Vector3(Random.Range(-2f, 2f), -3.6f,
                    obstacle.transform.position.z + Random.Range(2, 20));
                Vector3 targetUpPos = target - new Vector3(0, -3, (target.z - gameObject.transform.position.z) / 2);

                gameObject.transform.DOMove(targetUpPos, 0.1f).OnComplete(() =>
                {
                    gameObject.transform.DOMove(target, 0.1f);
                });

                if (gameObject.CompareTag("Money"))
                {
                    ScoreManager.Instance.ScoreValue--;
                    ScoreManager.Instance._scoreText.text = ScoreManager.Instance.ScoreValue.ToString();
                    gameObject.tag = "CollectableMoney";
                }
                else if (gameObject.CompareTag("Gold"))
                {
                    ScoreManager.Instance.ScoreValue -= 2;
                    ScoreManager.Instance._scoreText.text = ScoreManager.Instance.ScoreValue.ToString();
                    gameObject.tag = "CollectableGold";
                }
                else if (gameObject.CompareTag("Diamond"))
                {
                    ScoreManager.Instance.ScoreValue -= 3;
                    ScoreManager.Instance._scoreText.text = ScoreManager.Instance.ScoreValue.ToString();
                    gameObject.tag = "CollectableDiamond";
                }
            }
        }
    }
}