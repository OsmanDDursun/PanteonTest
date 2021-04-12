using PanteonRemoteTest.Abstract.Movements;
using PanteonRemoteTest.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonRemoteTest.Movements
{
    public class DonutMover : IObstacleMover
    {
        Transform _movingStick;

        public DonutMover(ObstacleController obstacleController)
        {
            _movingStick = obstacleController.transform.GetChild(0).transform.GetChild(0);
        }

        public void MoveAction(float moveSpeed)
        {
            // X 0.1 -> -0.67
            float nextPoint = Mathf.Abs(Mathf.Sin((Time.time / moveSpeed) * 2 * Mathf.PI));
            nextPoint *= -0.67f;
            _movingStick.transform.localPosition = new Vector3(nextPoint, _movingStick.transform.localPosition.y, _movingStick.transform.localPosition.z);
        }

    }
}