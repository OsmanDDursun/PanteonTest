using PanteonRemoteTest.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonRemoteTest.Movements
{
    public class CoinMover
    {
        CoinController _coinController;
        float _timer;
        bool _goingUp;
        Vector3 _startPosition;

        public CoinMover(CoinController coinController)
        {
            _coinController = coinController;
            _startPosition = _coinController.transform.position;
        }

        public void CoinMove(Vector3 direction, float floatSpeed, Vector3 rotation, float rotationSpeed)
        {
            if (_coinController.IsCollecting) return;
            if (rotationSpeed != 0f)
            {
                _coinController.transform.Rotate(rotation * rotationSpeed * Time.deltaTime);
            }

            if (floatSpeed != 0f)
            {
                float factor = Mathf.Sin((Time.time * floatSpeed / 5) * 2 * Mathf.PI);
                Vector3 offset = direction *= factor;
                _coinController.transform.position = offset + _startPosition;
            }
        }
    }
}