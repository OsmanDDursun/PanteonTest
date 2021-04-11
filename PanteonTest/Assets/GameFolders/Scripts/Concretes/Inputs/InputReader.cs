using PanteonRemoteTest.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PanteonRemoteTest.Inputs
{
    public class InputReader : MonoBehaviour
    {
        Vector3 _moveDirection;
        bool _canMove;

        public Vector3 MoveDirection => _moveDirection;
        public bool CanMove => _canMove;

        private void Update()
        {
            if (Input.GetMouseButton(0) && Input.mousePosition.y < Screen.height / 2)
            {
                _moveDirection = new Vector3(Map(Input.mousePosition.x, 0, Screen.width, -1, 1), 0f, Map(Input.mousePosition.y, 0, Screen.height / 2, -1, 1));
                _canMove = true;
            }
            else
            {
                _moveDirection = new Vector3(0f, 0f, 0f);
                _canMove = false;
            }
        }

        float Map(float val, float in1, float in2, float out1, float out2)
        {
            return Mathf.Clamp((out1 + (val - in1) * (out2 - out1) / (in2 - in1)), -1, 1);
        }
    }
}