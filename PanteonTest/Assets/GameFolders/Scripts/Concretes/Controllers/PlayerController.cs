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
        [SerializeField] float _moveSpeed = 10f;

        InputReader _input;
        HorizontalMover _mover;

        public float MoveSpeed => _moveSpeed;

        private void Awake()
        {
            _input = new InputReader(GetComponent<PlayerInput>());
            _mover = new HorizontalMover(this);
        }

        private void FixedUpdate()
        {
            Debug.Log(_input.MoveDirection);
            _mover.MoveAction(_input.MoveDirection); //karakter SağSol harketi
        }
    }
}