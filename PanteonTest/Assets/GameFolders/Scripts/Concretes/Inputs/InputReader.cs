using PanteonRemoteTest.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PanteonRemoteTest.Inputs
{
    public class InputReader
    {
        PlayerInput _playerInput;

        public Vector3 MoveDirection { get; private set; }

        public InputReader(PlayerInput playerInput)
        {
            _playerInput = playerInput;

            _playerInput.currentActionMap.actions[0].performed += OnMove;  //WASD Inputs

        }

        private void OnMove(InputAction.CallbackContext obj)
        {
            MoveDirection = new Vector3(obj.ReadValue<Vector2>().x, 0f, obj.ReadValue<Vector2>().y); //Hareket Yönü MoveDirection prop una tanımlandı Return (-1,+1)
        }
    }
}