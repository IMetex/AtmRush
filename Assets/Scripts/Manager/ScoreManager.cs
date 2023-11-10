using System;
using Singleton;
using TMPro;

namespace Manager
{
    public class ScoreManager : Singleton<ScoreManager>
    {
        public TMP_Text _scoreText;
        private int _scoreValue;

        public int ScoreValue
        {
            get => _scoreValue;
            set => _scoreValue = value;
        }

        private void Start()
        {
            _scoreValue = 0;
            _scoreText.text = _scoreValue.ToString();
        }
    }
    
}