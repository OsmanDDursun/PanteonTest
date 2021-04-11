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

        private void Update()
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, _playerController.transform.position.z - _offset);
        }
    }
}