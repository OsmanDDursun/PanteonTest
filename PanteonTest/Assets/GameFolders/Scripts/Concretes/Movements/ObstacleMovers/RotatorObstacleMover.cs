using PanteonRemoteTest.Abstract.Movements;
using PanteonRemoteTest.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PanteonRemoteTest.Movements
{
    public class RotatorObstacleMover : IObstacleMover
    {

        Transform _controller;

        public RotatorObstacleMover(ObstacleController obstacleController)
        {
            _controller = obstacleController.transform;
        }

        public void MoveAction(float moveSpeed)
        {
            //_controller.rotation = Quaternion.Euler(Vector3.up * Time.deltaTime * moveSpeed);
            _controller.Rotate(Vector3.up * Time.deltaTime * moveSpeed);
        }
    }
}