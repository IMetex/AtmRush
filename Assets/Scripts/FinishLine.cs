using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [Header("Components")] [SerializeField]
    private Move _component;

    [SerializeField] private GameObject _player;

    private int count = 3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            _component.enabled = false;
            int stackCount = PlayerManager.Instance.collected.Count - 1;

            Vector3 finalPosition = _player.transform.position + Vector3.forward * stackCount * count;
            float duration = 0.5f * stackCount * count;

            _player.transform.DOMove(finalPosition, duration)
                .OnComplete(() => { GameStateUI(stackCount); });
        }

        if (other.CompareTag("Gate"))
        {
            int stackCount = PlayerManager.Instance.collected.Count - 1;
            if (stackCount <= 0)
            {
                GameStateScreen.Instance.Lose();
                _component.enabled = false;
            }
        }
    }

    private void GameStateUI(int count)
    {
        if (count > 0)
        {
            GameStateScreen.Instance.Win();
        }
        else
        {
            GameStateScreen.Instance.Lose();
        }
    }
}