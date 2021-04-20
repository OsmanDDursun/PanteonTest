using PanteonRemoteTest.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonRemoteTest.Controllers
{
    public class PlatformController : MonoBehaviour
    {
        [SerializeField] float _moveSpeed = 5f;
        [SerializeField] bool _isLeft = false;
        float _direction;
        PlatformRotator platformRotator;

        private void Awake()
        {
            platformRotator = new PlatformRotator(this);
            if (_isLeft) { _direction = 1; } else { _direction = -1; }
        }

        private void FixedUpdate()
        {
            platformRotator.MoveAction(_moveSpeed, _direction);
        }
    }
}