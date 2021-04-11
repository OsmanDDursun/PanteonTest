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

        public float MoveDirection { get; private set; }

        public InputReader(PlayerInput playerInput)
        {
            _playerInput = playerInput;

            _playerInput.currentActionMap.actions[0].performed += OnHorizontalMove;  //AD Inputs

        }

        private void OnHorizontalMove(InputAction.CallbackContext obj)
        {
            MoveDirection = obj.ReadValue<float>(); //Hareket Yönü MoveDirection prop una tanımlandı Sağ +1 Sol -1
        }
    }
}