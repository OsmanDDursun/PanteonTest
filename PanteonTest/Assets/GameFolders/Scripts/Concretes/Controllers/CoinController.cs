using PanteonRemoteTest.Managers;
using PanteonRemoteTest.Movements;
using PanteonRemoteTest.UIs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PanteonRemoteTest.Controllers
{
    public class CoinController : MonoBehaviour
    {
        [SerializeField] Vector3 _moveDirection = new Vector3(0f, 0.2f, 0f);
        [SerializeField] float _moveSpeed = 2f;
        [SerializeField] Vector3 _rotateDirection = new Vector3(0f, 5f, 0f);
        [SerializeField] float _rotateSpeed = 20f;


        CoinMover _coinMover;
        bool _isCollecting = false;

        private void Awake()
        {
            _coinMover = new CoinMover(this);
        }

        private void FixedUpdate()
        {
            if (!_isCollecting)
            {
                _coinMover.CoinMove(_moveDirection, _moveSpeed, _rotateDirection, _rotateSpeed);
            }
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.TryGetComponent(out PlayerController player))
            {
                PickUpCoin();
            }
        }

        void PickUpCoin()
        {
            _isCollecting = true;
            StartCoroutine(_coinMover.MoveToImage());
            ScoreManager.Instance.PickUpCoin();
        }
    }
}