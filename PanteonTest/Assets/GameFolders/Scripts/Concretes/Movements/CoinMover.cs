using PanteonRemoteTest.Controllers;
using PanteonRemoteTest.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonRemoteTest.Movements
{
    public class CoinMover
    {
        CoinController _coinController;
        Vector3 _startPosition;

        public CoinMover(CoinController coinController)
        {
            _coinController = coinController;
            _startPosition = _coinController.transform.position;
        }

        public void CoinMove(Vector3 direction, float floatSpeed, Vector3 rotation, float rotationSpeed)
        {
            if (rotationSpeed != 0f)
            {
                _coinController.transform.Rotate(rotation * rotationSpeed * Time.deltaTime);
            }

            if (floatSpeed != 0f)
            {
                float factor = Mathf.Sin((Time.time * floatSpeed / 5) * 2 * Mathf.PI);
                Vector3 offset = direction * factor;
                _coinController.transform.position = offset + _startPosition;
            }
        }

        public IEnumerator MoveToImage()
        {
            while (true)
            {
                yield return new WaitForEndOfFrame();
                Vector3 scoreImagePos = Camera.main.ScreenToWorldPoint(ScoreManager.Instance.ScoreImage.transform.position + Vector3.forward * CameraController.CameraFollowOffset);
                _coinController.transform.localScale = _coinController.transform.localScale / 1.01f;
                _coinController.transform.position = Vector3.MoveTowards(_coinController.transform.position, scoreImagePos, 20f * Time.deltaTime);
                if (_coinController.transform.localScale.x < 0.4f)
                {
                    _coinController.gameObject.SetActive(false);
                    //Poolling sistem eklendiğinde pool a gönderilecek
                    break;
                }
            }
        }
    }
}