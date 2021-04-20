using PanteonRemoteTest.Managers;
using PanteonRemoteTest.Movements;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonRemoteTest.Controllers
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] Camera _paintSceneCam;

        CameraMover _cameraMover;
        PlayerController _playerController;

        Vector3 _camOldPos;
        Quaternion _camOldRotation;

        float _followOffset;
        bool _isPaintCamReady;
        bool _canFollow = true;
        public PlayerController Player => _playerController;

        private void Awake()
        {
            _playerController = FindObjectOfType<PlayerController>();
            _cameraMover = new CameraMover(this);
            _camOldPos = transform.position;
            _camOldRotation = transform.rotation;
            _followOffset = Mathf.Abs(_playerController.transform.position.z - transform.position.z);
        }

        private void FixedUpdate()
        {

            if(GameManager.Instance.GameState == GameManager.GameStates.PaintingGame)
            {
                if (!_isPaintCamReady)
                {
                    _cameraMover.PaintingCamera(_paintSceneCam, ref _isPaintCamReady);
                    _canFollow = false;
                }
            }
            else
            {
                if(_canFollow)
                    _cameraMover.FollowPlayerWhileRunning(_followOffset);
            }
        }

        private void OnEnable()
        {
            GameManager.Instance.OnPaintingGameOver += HandleOnPaintingGameOver;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnPaintingGameOver -= HandleOnPaintingGameOver;
        }

        private void HandleOnPaintingGameOver()
        {
            GetComponent<Camera>().enabled = true;
            _paintSceneCam.gameObject.GetComponent<Camera>().enabled = false;
            gameObject.transform.position = _camOldPos;
            gameObject.transform.rotation = _camOldRotation;
            _canFollow = true;
            _isPaintCamReady = false;
        }

    }
}


