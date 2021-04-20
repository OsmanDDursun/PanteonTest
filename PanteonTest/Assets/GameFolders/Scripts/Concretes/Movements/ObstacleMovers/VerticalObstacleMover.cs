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
            float nextPoint = Mathf.Sin((Time.time * moveSpeed / 5) * 2 * Mathf.PI);
            nextPoint *= 12f;
            _obstacle.localPosition = new Vector3(nextPoint, _obstacle.localPosition.y, _obstacle.localPosition.z);
        }
    }
}