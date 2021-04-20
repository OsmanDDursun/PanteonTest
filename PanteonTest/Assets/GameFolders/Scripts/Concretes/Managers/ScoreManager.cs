using PanteonRemoteTest.Abstract.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

namespace PanteonRemoteTest.Managers
{
    public class ScoreManager : SingletonObject<ScoreManager>
    {
        [SerializeField] TMP_Text _scoreText;
        [SerializeField] GameObject _scoreImage;

        int _currentScore;

        public event Action OnScoreGain;
        public event Action OnResetScore;

        public GameObject ScoreImage => _scoreImage;
        public int CurrentScore => _currentScore;

        private void Awake()
        {
            MakeThisSingleton(this);
        }

        private void OnEnable()
        {
            GameManager.Instance.OnGameReady += ResetScore;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnGameReady -= ResetScore;
        }

        void UpdateScore()
        {
            _scoreText.text = _currentScore.ToString();
        }

        public void GainScore(int score)
        {
            _currentScore += score;
            UpdateScore();
            OnScoreGain?.Invoke();
        }

        void ResetScore()
        {
            _currentScore = 0;
            UpdateScore();
            OnResetScore?.Invoke();
        }

    }
}