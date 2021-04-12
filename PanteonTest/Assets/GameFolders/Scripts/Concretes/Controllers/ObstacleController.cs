using PanteonRemoteTest.Abstract.Movements;
using PanteonRemoteTest.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonRemoteTest.Controllers
{
    public class ObstacleController : MonoBehaviour
    {
        [SerializeField] float _moveSpeed = 5f;

        IObstacleMover _obstacle;

        private void Awake()
        {
           switch (transform.tag)
            {
                case "HalfDonutObstacle":
                    { _obstacle = new DonutMover(this); }
                    break;
                case "RotatorObstacle":
                    { _obstacle = new RotatorObstacleMover(this); }
                    break;
                case "VerticalMovingObstacle":
                    { _obstacle = new VerticalObstacleMover(this); };
                    break;
                default:
                    break;
            }

        }

        private void Update()
        {
            if(_obstacle != null) _obstacle.MoveAction(_moveSpeed);
        }
    }
}