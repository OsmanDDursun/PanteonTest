using PanteonRemoteTest.Abstract.Managers;
using PanteonRemoteTest.Controllers;
using PanteonRemoteTest.ScriptableObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PanteonRemoteTest.Managers
{
    public class GameManager : SingletonObject<GameManager>
    {
        [SerializeField] GameData[] _levelData;

        public event Action OnPlayerWin;
        public event Action OnPlayerLose;
        public event Action OnPaintDone;

        public event Action OnGameReady;
        public event Action OnGameOver;
        public event Action OnGameStart;

        public event Action OnPaintingGameReady;
        public event Action OnPaintingGameStart;
        public event Action OnPaintingGameOver;


        //public GameData LevelData => _levelData[CurrentLevel];
        public GameData[] LevelConfig => _levelData;
        public bool IsGameOver { get; private set; }

        [HideInInspector]
        public enum GameStates { 
            Prepare,
            Playing,
            Finish,
            PaintingPrepare,
            PaintingGame,
            PaintingGameFinish,
        }

        public GameStates GameState { get; private set; }

        private void Awake()
        {
            MakeThisSingleton(this);            
        }

        private void Start()
        {
            InitializeLevel();
        }

        public void InitializeLevel()
        {
            IsGameOver = false;
            ReadyGame();
            SpawnController spawnController = FindObjectOfType<SpawnController>();
            spawnController.CreateScene();
        }

        /*EVENTS*/
        public void PaintDone()
        {
            GameState = GameStates.PaintingGameFinish;
            OnPaintDone?.Invoke();
        }

        public void PaintingGameOver()
        {
            OnPaintingGameOver?.Invoke();
            InitializeLevel();
        }
        public void InitializePaintingGame()
        {

            //Boyamaya başla
            IsGameOver = false;
            GameState = GameStates.PaintingGame;
            OnPaintingGameStart?.Invoke();
        }

        public void GetPaintingGameReady()
        {
            //Platformun Çıkışı (Spawn Controller)
            //kamera Geçişi (CameraController)
            //Player platforma doğru yürür(Character Controller)(PlayerMove)
            //input Disabled(InputReader)
            //Player pozisyonu istenen pozisyonda ise InitializePaintingGame (playerController)
            GameState = GameStates.PaintingPrepare;
            OnPaintingGameReady?.Invoke();
        }

        public void ReadyGame()
        {
            GameState = GameStates.Prepare;
            OnGameReady?.Invoke();
        }

        public void StartGame()
        {
            //Hareketi VER
            GameState = GameStates.Playing;
            OnGameStart?.Invoke();
        }

        public void PlayerLoseGame()
        {
            if (IsGameOver) return;
            if (GameState != GameStates.Playing) return;
            GameState = GameStates.Finish;
            OnPlayerLose?.Invoke();
            GameOver();
        }

        public void PlayerWinGame()
        {
            if (IsGameOver) return;
            GameState = GameStates.Finish;
            OnPlayerWin?.Invoke();
            GameOver();
        }

        void GameOver()
        {
            IsGameOver = true;
            OnGameOver?.Invoke();
        }
        /*EVENTS*/

    }
}