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

        InputReader _input;
        PlayerMover _mover;

        public float HorizontalMoveSpeed => _horizontalMoveSpeed;

        private void Awake()
        {
            _input = new InputReader(GetComponent<PlayerInput>());
            _mover = new PlayerMover(this);
        }

        private void FixedUpdate()
        {
            Debug.Log(_input.MoveDirection);
            _mover.MoveAction(_input.MoveDirection, _horizontalMoveSpeed); //karakter SağSol harketi
        }
    }
}