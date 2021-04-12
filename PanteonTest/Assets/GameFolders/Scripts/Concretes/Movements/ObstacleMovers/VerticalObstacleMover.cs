using PanteonRemoteTest.Abstract.Movements;
using PanteonRemoteTest.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonRemoteTest.Movements
{
    public class VerticalObstacleMover : IObstacleMover
    {
        Transform _obstacle;

        public VerticalObstacleMover(ObstacleController controller)
        {
            _obstacle = controller.transform;
        }

        public void MoveAction(float moveSpeed)
        {
            float nextPoint = Mathf.Sin((Time.time / moveSpeed) * 2 * Mathf.PI);
            nextPoint *= 13f;
            _obstacle.position = new Vector3(nextPoint, _obstacle.position.y, _obstacle.position.z);
        }
    }
}