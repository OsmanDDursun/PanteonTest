using PanteonRemoteTest.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonRemoteTest.Movements
{
    public class PlayerMover
    {
        CharacterController _characterController;

        public PlayerMover(PlayerController playerController)
        {
            _characterController = playerController.transform.GetComponent<CharacterController>();
        }

        public void MoveAction (Vector3 direction, float moveSpeed)
        {
            if (direction == Vector3.zero) return;

            Vector3 worldPosition = _characterController.transform.TransformDirection(Vector3.forward);
            Vector3 movement = worldPosition * Time.deltaTime * moveSpeed;
            _characterController.Move(movement);
        }
    }
}