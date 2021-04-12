using PanteonRemoteTest.Inputs;
using PanteonRemoteTest.Movements;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonRemoteTest.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float _horizontalMoveSpeed = 10f;
        [SerializeField] float _rotateSpeed = 10f;

        InputReader _input;
        PlayerMover _mover;
        PlayerRotator _playerRotator;
        AnimationController _animationController;

        public float HorizontalMoveSpeed => _horizontalMoveSpeed;
        public bool IsRunning => _input.IsRunning;

        private void Awake()
        {
            _input = GetComponent<InputReader>();
            _mover = new PlayerMover(this);
            _playerRotator = new PlayerRotator(this);
            _animationController = new AnimationController(this);

        }

        private void FixedUpdate()
        {
            //Debug.Log(_input.MoveDirection);
            _mover.MoveAction(_input.MoveDirection, _horizontalMoveSpeed);
            _playerRotator.RotatePlayer(_input.MoveDirection, _rotateSpeed);
        }

        private void LateUpdate()
        {
            _animationController.MoveAnimation(Convert.ToSingle(IsRunning));
        }
    }
}