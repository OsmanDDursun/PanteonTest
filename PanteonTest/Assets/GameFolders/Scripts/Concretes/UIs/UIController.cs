using PanteonRemoteTest.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PanteonRemoteTest.UIs
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] GameObject _mainMenu;
        [SerializeField] GameObject _gamingUI;
        [SerializeField] GameObject _gameOverUI;
        [SerializeField] GameObject _successUI;
        [SerializeField] GameObject _playerIcon;
        [SerializeField] GameObject _paintUI;
        [SerializeField] GameObject _soundOnImage;
        [SerializeField] GameObject _soundOffImage;

        private void OnEnable()
        {
            GameManager.Instance.OnPlayerWin += HandleOnPlayerWin;
            GameManager.Instance.OnPlayerLose += HandleOnPlayerLose;
            GameManager.Instance.OnGameReady += HandleOnGameReady;
            GameManager.Instance.OnGameStart += HandleOnGameStart;
            GameManager.Instance.OnPaintingGameStart += HandleOnPaintGameStart;
            GameManager.Instance.OnPaintingGameReady += HandleOnPaintGameReady;
            GameManager.Instance.OnPaintDone += HandleOnPaintDone;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnPlayerWin -= HandleOnPlayerWin;
            GameManager.Instance.OnPlayerLose -= HandleOnPlayerLose;
            GameManager.Instance.OnGameReady -= HandleOnGameReady;
            GameManager.Instance.OnGameStart -= HandleOnGameStart;
            GameManager.Instance.OnPaintingGameStart -= HandleOnPaintGameStart;
            GameManager.Instance.OnPaintingGameReady -= HandleOnPaintGameReady;
            GameManager.Instance.OnPaintDone -= HandleOnPaintDone;
        }

        private void HandleOnPaintDone()
        {
            ResetUIs();
            _successUI.SetActive(true);
        }

        private void HandleOnGameStart()
        {
            ResetUIs();
            _gamingUI.SetActive(true);
            _playerIcon.SetActive(true);
        }

        private void HandleOnGameReady()
        {
            BackToMainMenu();
        }

        private void HandleOnPlayerWin()
        {
            ResetUIs();
            _successUI.SetActive(true);
        }

        private void HandleOnPlayerLose()
        {
            ResetUIs();
            _gameOverUI.SetActive(true);
        }

        private void HandleOnPaintGameStart()
        {
            ResetUIs();
            _paintUI.SetActive(true);
        }

        private void HandleOnPaintGameReady()
        {
            ResetUIs();
        }

        public void PlayBTN()
        {
            GameManager.Instance.StartGame();
        }

        public void ReplayBTN()
        {
            GameManager.Instance.InitializeLevel();
            BackToMainMenu();
        }

        public void NextLevelBTN()
        {
            if (GameManager.Instance.GameState == GameManager.GameStates.PaintingGameFinish)
                GameManager.Instance.PaintingGameOver();
            else
                GameManager.Instance.GetPaintingGameReady();
        }

        public void BackToMainMenu()
        {
            ResetUIs();
            _mainMenu.SetActive(true);
        }

        public void ResetUIs()
        {
            _mainMenu.SetActive(false);
            _successUI.SetActive(false);
            _gameOverUI.SetActive(false);
            _playerIcon.SetActive(false);
            _gamingUI.SetActive(false);
            _paintUI.SetActive(false);
        }

        public void SoundBTN()
        {
            if (SoundManager.Instance.IsSoundOff)
            {
                _soundOnImage.SetActive(true);
                _soundOffImage.SetActive(false);
            }
            else
            {
                _soundOnImage.SetActive(false);
                _soundOffImage.SetActive(true);
            }
            SoundManager.Instance.SoundOnOff();
        }

        public void CloseBTN()
        {
            Application.Quit();
        }

    }

}