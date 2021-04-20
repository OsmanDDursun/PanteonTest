using PanteonRemoteTest.Abstract.Movements;
using PanteonRemoteTest.Managers;
using PanteonRemoteTest.Movements;
using PanteonRemoteTest.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonRemoteTest.Controllers
{
    public class ObstacleController : MonoBehaviour
    {
        IObstacleMover _obstacle;
        [SerializeField] float _direction = 1;

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
                case "HorizontalDynamicObstacle":
                    { _obstacle = new VerticalObstacleMover(this); };
                    break;
                default:
                    break;
            }

        }

        private void Update()
        {
            if (_obstacle == null) return;
            _obstacle.MoveAction(_direction * 1f);
        }
    }
}