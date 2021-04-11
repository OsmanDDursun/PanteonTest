using PanteonRemoteTest.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonRemoteTest.Movements
{
    public class HorizontalMover
    {
        PlayerController _playerController;

        public HorizontalMover(PlayerController playerController)
        {
            _playerController = playerController;
        }

        public void MoveAction (float direction)
        {
            if (direction == 0f) return;

            _playerController.transform.Translate(Vector3.right * Time.deltaTime * direction * _playerController.MoveSpeed);
        }
    }
}