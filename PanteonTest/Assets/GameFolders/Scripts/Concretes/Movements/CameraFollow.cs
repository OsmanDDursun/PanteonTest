using PanteonRemoteTest.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonRemoteTest.Movements
{
    public class CameraFollow : MonoBehaviour
    {
        PlayerController _playerController;

        float _offset;
        private void Awake()
        {
            _playerController = FindObjectOfType<PlayerController>();
            _offset = Mathf.Abs(_playerController.transform.position.z - transform.position.z);
        }

        void FixedUpdate()
        {
            Vector3 targetPos = new Vector3(_playerController.transform.position.x, transform.position.y, _playerController.transform.position.z - _offset);
            Vector3 smoothPos = Vector3.Lerp(transform.position, targetPos, 0.125f);
            transform.position = smoothPos;

        }
    }
}