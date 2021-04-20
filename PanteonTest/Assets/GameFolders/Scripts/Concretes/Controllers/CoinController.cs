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
        [SerializeField] Vector3 _moveDirection = new Vector3 (0f,0.2f,0f);
        [SerializeField] float _moveSpeed = 2f;
        [SerializeField] Vector3 _rotateDirection = new Vector3(0f, 5f, 0f);
        [SerializeField] float _rotateSpeed = 20f;
        GameObject _scoreImage;
        bool _isCollect;

        public bool IsCollecting => _isCollect;

        CoinMover _coinMover;
        PlayerController _player;

        private void Awake()
        {
            _coinMover = new CoinMover(this);
            _scoreImage = ScoreManager.Instance.ScoreImage;
        }

        private void FixedUpdate()
        {
            _coinMover.CoinMove(_moveDirection, _moveSpeed, _rotateDirection, _rotateSpeed);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.TryGetComponent(out PlayerController player))
            {
                _isCollect = true;
                _player = player;
                ScoreManager.Instance.GainScore(1);
            }
        }

        private void Update()
        {
            PickUpCoin();
        }

        void PickUpCoin()
        {
            if (!_isCollect) return;
            Vector3 offset = new Vector3(0f, 0f, _player.transform.position.z - Camera.main.transform.position.z);
            Vector3 scoreImagePos = _scoreImage.transform.position + offset;
            scoreImagePos = Camera.main.ScreenToWorldPoint(scoreImagePos);
            
            transform.localScale = transform.localScale / 1.01f;
            transform.position = Vector3.MoveTowards(transform.position, scoreImagePos, 20f * Time.deltaTime);
            if (transform.localScale.x < 0.4f) Destroy(gameObject);

        }
    }
}