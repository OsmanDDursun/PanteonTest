using PanteonRemoteTest.Controllers;
using System.Collections;
using UnityEngine;

namespace PanteonRemoteTest.Movements
{
    public class PlayerRotator
    {
        private PlayerController _playerController;

        public PlayerRotator(PlayerController playerController)
        {
            _playerController = playerController;
        }

        public void RotatePlayer(float direction, float rotateSpeed)
        {
            direction *= rotateSpeed * Time.fixedDeltaTime;
            _playerController.transform.Rotate(Vector3.up * direction);
        }
    }
}