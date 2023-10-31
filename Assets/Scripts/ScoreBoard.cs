using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    [Space(10)] [Header("Scoard Board List")]
    public GameObject[] scoreBoard;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ScoreBoard") || other.CompareTag("Finish"))
        {
            int collectedCount = PlayerManager.Instance.collected.Count - 1;

            if (collectedCount > 0 && collectedCount <= scoreBoard.Length)
            {
                StartCoroutine(OpenScoreboardsSequentially(collectedCount));
            }
        }
    }

    private IEnumerator OpenScoreboardsSequentially(int count)
    {
        for (int i = 0; i < count; i++)
        {
            if (i >= 0 && i < scoreBoard.Length)
            {
                scoreBoard[i].SetActive(true);
                scoreBoard[i].transform.DOMoveY(-0.45f, 0.6f);
                yield return new WaitForSeconds(0.8f);
            }
        }
    }
}