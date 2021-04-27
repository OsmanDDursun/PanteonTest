using PanteonRemoteTest.Abstract.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using PanteonRemoteTest.Controllers;
using PanteonRemoteTest.Movements;

namespace PanteonRemoteTest.Managers
{
    public class ScoreManager : SingletonObject<ScoreManager>
    {
        [SerializeField] TMP_Text _scoreText;
        [SerializeField] GameObject _scoreImage;

        int _currentScore;

        public event Action OnCoinPickUp;


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

        public void GainScore(int score = 1)
        {
            _currentScore += score;
            UpdateScore();
        }

        void ResetScore()
        {
            _currentScore = 0;
            UpdateScore();
        }

        public void PickUpCoin()
        {
            GainScore();
            OnCoinPickUp?.Invoke();
        }
    }
}