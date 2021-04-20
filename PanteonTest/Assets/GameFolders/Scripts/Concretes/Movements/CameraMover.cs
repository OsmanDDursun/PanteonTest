using PanteonRemoteTest.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonRemoteTest.Movements
{
    public class CameraMover
    {
        PlayerController _playerController;
        CameraController _cameraController;

        public CameraMover(CameraController cameraController)
        {
            _cameraController = cameraController;
            _playerController = cameraController.Player;
        }


        public void FollowPlayerWhileRunning(float offset)
        {
            Vector3 targetPos = new Vector3(_playerController.transform.position.x, _cameraController.transform.position.y, _playerController.transform.position.z - offset);
            Vector3 smoothPos = Vector3.Lerp(_cameraController.transform.position, targetPos, 0.125f);
            _cameraController.transform.position = smoothPos;
        }

        public void PaintingCamera(Camera targetCam, ref bool isPaintCamReady)
        {
            if(Vector3.Distance(targetCam.transform.position,_cameraController.transform.position) < 1)
            {
                isPaintCamReady = true;
                targetCam.gameObject.GetComponent<Camera>().enabled = true;
                _cameraController.gameObject.GetComponent<Camera>().enabled = false;
            }

            Vector3 smoothPos = Vector3.Lerp(_cameraController.transform.position, targetCam.transform.position, 0.125f);
            Quaternion smoothRotation = Quaternion.Lerp(_cameraController.transform.rotation, targetCam.transform.rotation, 0.125f);
            _cameraController.transform.position = smoothPos;
            _cameraController.transform.rotation = smoothRotation;
        }
    }
}