using PanteonRemoteTest.Inputs;
using PanteonRemoteTest.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PanteonRemoteTest.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float _horizontalMoveSpeed = 10f;
        [SerializeField] float _rotateSpeed = 10f;

        InputReader _input;
        PlayerMover _mover;
        PlayerRotator _playerRotator;

        public float HorizontalMoveSpeed => _horizontalMoveSpeed;

        private void Awake()
        {
            _input = GetComponent<InputReader>();
            _mover = new PlayerMover(this);
            _playerRotator = new PlayerRotator(this);

        }

        private void FixedUpdate()
        {
            Debug.Log(_input.MoveDirection);
            _playerRotator.RotatePlayer(_input.MoveDirection, _rotateSpeed);
            _mover.MoveAction(_input.MoveDirection, _horizontalMoveSpeed);
        }
    }
}