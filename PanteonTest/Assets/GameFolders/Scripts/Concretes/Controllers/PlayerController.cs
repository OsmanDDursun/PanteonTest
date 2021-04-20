using PanteonRemoteTest.Inputs;
using PanteonRemoteTest.Managers;
using PanteonRemoteTest.Movements;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace PanteonRemoteTest.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float _horizontalMoveSpeed = 100f;
        [SerializeField] float _rotateSpeed = 400f;
        [SerializeField] GameObject _paintGameTarget;

        InputReader _input;
        PlayerRBMover _mover;
        PlayerRotator _playerRotator;
        PlayerAnimationController _animationController;
        Vector3 _startPos;
        NavMeshAgent _playerAgent;
        public float HorizontalMoveSpeed => _horizontalMoveSpeed;
        public bool IsRunning => _input.IsRunning;

        private void Awake()
        {
            _input = GetComponent<InputReader>();
            _mover = new PlayerRBMover(this);
            _playerRotator = new PlayerRotator(this);
            _animationController = new PlayerAnimationController(this);
            _startPos = transform.position;
            _playerAgent = GetComponent<NavMeshAgent>();

        }

        private void Update()
        {
            _animationController.MoveAnimation(_horizontalMoveSpeed);
            if (GameManager.Instance.GameState == GameManager.GameStates.Playing)
            {
                if (Vector3.Distance(transform.position, new Vector3(0f, 0f, 220f)) < 5)
                {
                    GameManager.Instance.PlayerWinGame();
                }
                if (transform.position.y < -5) GameManager.Instance.PlayerLoseGame();
            }

            if (GameManager.Instance.GameState == GameManager.GameStates.PaintingPrepare)
            {
                if(Vector3.Distance(transform.position,_paintGameTarget.transform.position) < 1)
                {
                    GameManager.Instance.InitializePaintingGame();
                    _animationController.PlayAnimation("PaintIdle");
                }
            }
        }

        private void FixedUpdate()
        {
            if (GameManager.Instance.GameState == GameManager.GameStates.Playing && IsRunning)
            {
                //Debug.Log(_input.MoveDirection);
                _mover.MoveAction(_horizontalMoveSpeed);
                _playerRotator.RotatePlayer(_input.MoveDirection, _rotateSpeed);
            }
        }

        private void OnCollisionExit (Collision collision)
        {
            if (collision.transform.CompareTag("RotatingPlatform"))
            {
                transform.parent = null;
            }
        }

        private void OnCollisionStay(Collision collision)
        {
            if (collision.transform.CompareTag("RotatingPlatform"))
            {
                transform.parent = collision.transform;
            }
        }

        private void OnEnable()
        {
            GameManager.Instance.OnGameReady += HandleOnGameReady;
            GameManager.Instance.OnPaintingGameReady += HandleOnPaintGameReady;
            GameManager.Instance.OnPaintingGameOver += HandleOnPaintingGameOver;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnGameReady -= HandleOnGameReady;
            GameManager.Instance.OnPaintingGameReady -= HandleOnPaintGameReady;
            GameManager.Instance.OnPaintingGameOver -= HandleOnPaintingGameOver;
        }

        private void HandleOnPaintingGameOver()
        {
            _playerAgent.enabled = false;
            GetComponent<NavMeshObstacle>().enabled = true;
        }

        private void HandleOnPaintGameReady()
        {
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<NavMeshObstacle>().enabled = false;
            _playerAgent.enabled = true;
            _playerAgent.destination = _paintGameTarget.transform.position;
            _animationController.ResetAnimations();
            _animationController.PlayAnimation("Walking");
        }

        private void HandleOnGameReady()
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.position = _startPos;
            transform.rotation = Quaternion.Euler(Vector3.zero);
            _animationController.ResetAnimations();
            GetComponent<Rigidbody>().isKinematic = false;
        }

        public void HitObstacles()
        {
            _animationController.PlayAnimation("Fall");
            GameManager.Instance.PlayerLoseGame();
        }



    }
}