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

        public void RotatePlayer(Vector3 direction, float rotateSpeed)
        {
            // (-1,0,-1) - (1,0,1)
            direction *= rotateSpeed * Time.deltaTime;
            _playerController.transform.rotation = Quaternion.Euler(new Vector3(0f, direction.x, 0f));
            //_playerController.transform.Rotate(Vector3.up * direction.x * Time.deltaTime * rotateSpeed);
        }
    }
}