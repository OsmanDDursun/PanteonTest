using PanteonRemoteTest.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonRemoteTest.Movements
{
    public class PlatformRotator
    {
        Transform _platform;


        public PlatformRotator(PlatformController platformController)
        {
            _platform = platformController.transform;
            _platform = _platform.GetChild(0);
        }

        public void MoveAction(float moveSpeed, float direction)
        {
            if (_platform == null) return;
            _platform.Rotate(Vector3.forward * direction * Time.deltaTime * moveSpeed);
        }

    }
}