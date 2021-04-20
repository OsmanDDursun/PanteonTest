using PanteonRemoteTest.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonRemoteTest.Movements
{
    public class PlayerRBMover
    {
        PlayerController _playerController;

        public PlayerRBMover(PlayerController playerController)
        {
            _playerController = playerController;
        }

        public void MoveAction(float moveSpeed)
        {
            Vector3 direction = Vector3.forward * Time.fixedDeltaTime * moveSpeed;
            _playerController.transform.Translate(direction);
        }
    }
}