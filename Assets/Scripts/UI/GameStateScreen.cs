using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateScreen : Singletion<GameStateScreen>
{
    [Header("UI Panels")] [Space(10)]
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _loseScreen;
    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private TMP_Text _valueText;

    private bool isStarded = false;
    public bool IsStartded => isStarded;
    private int multipier = 100;


    private void Start()
    {
        _gameScreen.SetActive(true);
        _winScreen.SetActive(false);
        _loseScreen.SetActive(false);
    }

    public void Win()
    {
        _winScreen.SetActive(true);
        _loseScreen.SetActive(false);
        int stackCount = StackManager.Instance.stackValue;
        stackCount *= multipier;
        _valueText.text = "Score: " + stackCount.ToString();
    }

    public void Lose()
    {
        _winScreen.SetActive(false);
        _loseScreen.SetActive(true);
    }

    public void StartGame()
    {
        _gameScreen.SetActive(false);
        isStarded = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}