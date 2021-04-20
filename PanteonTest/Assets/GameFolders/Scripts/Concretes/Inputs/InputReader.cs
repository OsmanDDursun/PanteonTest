using PanteonRemoteTest.Controllers;
using PanteonRemoteTest.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PanteonRemoteTest.Inputs
{
    public class InputReader : MonoBehaviour
    {
        bool  _isDraging;
        bool  _isRunning;
        bool  _isPainting;
        Vector3 _mousePos;

        float _mouseDeltaX;

        bool _inputDisabled;

        public float MoveDirection => _mouseDeltaX;
        public bool IsRunning => _isRunning;
        public bool IsPainting => _isPainting;
        public Vector3 MousePosition => _mousePos;

        private void Update()
        {
            if (GameManager.Instance.GameState == GameManager.GameStates.Prepare)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (EventSystem.current.currentSelectedGameObject?.GetComponent<Button>() == null)
                    {
                        GameManager.Instance.StartGame();
                    }
                      
                }
            }

            _mouseDeltaX = Mathf.Clamp(Input.GetAxis("Mouse X"), -1f, 1f);
            _mousePos = Input.mousePosition;

            _isDraging = Input.GetMouseButton(0) && !_inputDisabled;


            if (GameManager.Instance.GameState != GameManager.GameStates.Playing) { _isRunning = false; } else { _isRunning = _isDraging; }
            if (GameManager.Instance.GameState != GameManager.GameStates.PaintingGame) { _isPainting = false; } else { _isPainting = _isDraging; }
        }

        private void OnEnable()
        {
            GameManager.Instance.OnGameOver += DisableInput;
            GameManager.Instance.OnGameStart += EnableInput;
            GameManager.Instance.OnPaintingGameStart += EnableInput;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnGameOver -= DisableInput;
            GameManager.Instance.OnGameStart -= EnableInput;
            GameManager.Instance.OnPaintingGameStart -= EnableInput;
        }

        private void DisableInput()
        {
            _inputDisabled = true;
        }
        private void EnableInput()
        {
            _inputDisabled = false;
        }
    }
}