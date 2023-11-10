using System.Collections;
using System.Collections.Generic;
using Manager;
using Singleton;
using Stack;
using UnityEngine;

public class DestroyObjects : Singleton<DestroyObjects>
{
    [Header("Partical System")] [SerializeField]
    public ParticleSystem moneyDestroyPartical;
    //  [SerializeField] public ParticleSystem goldDestroyPartical;
    // [SerializeField] public ParticleSystem diamondDestroyPartical;


    public void DestroyMoney(GameObject other, int index, GameObject obstacle)
    {
        if (index == 0)
        {
            index = 1;
        }

        int countList = StackLerpMovement.Instance.collected.Count;

        for (int i = index; i < countList; i++)
        {
            GameObject gameObject = StackLerpMovement.Instance.collected[i];

            if (i == StackLerpMovement.Instance.collected.Count - 1)
            {
                Instantiate(moneyDestroyPartical, obstacle.transform.position + new Vector3(0, 1, 0),
                    Quaternion.identity);
            }

            if (gameObject.CompareTag("Money"))
            {
                ScoreManager.Instance.ScoreValue--;
                ScoreManager.Instance._scoreText.text = ScoreManager.Instance.ScoreValue.ToString();
            }
            else if (gameObject.CompareTag("Gold"))
            {
                ScoreManager.Instance.ScoreValue -= 2;
                ScoreManager.Instance._scoreText.text = ScoreManager.Instance.ScoreValue.ToString();
            }
            else if (gameObject.CompareTag("Diamond"))
            {
                ScoreManager.Instance.ScoreValue -= 2;
                ScoreManager.Instance._scoreText.text = ScoreManager.Instance.ScoreValue.ToString();
            }

            Destroy(gameObject);
        }
        StackLerpMovement.Instance.collected.RemoveRange(index, StackLerpMovement.Instance.collected.Count - index);
    }
}