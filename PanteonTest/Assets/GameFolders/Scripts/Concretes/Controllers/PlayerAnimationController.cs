using PanteonRemoteTest.Abstract.Controllers;
using PanteonRemoteTest.Inputs;
using PanteonRemoteTest.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonRemoteTest.Controllers
{
    public class PlayerAnimationController : AnimationController
    {
        PlayerController _playerController;

        public override bool IsRunning => _playerController.IsRunning;

        public PlayerAnimationController(PlayerController playerController)
        {
            _playerController = playerController;
            _animator = _playerController.GetComponentInChildren<Animator>();
            GameManager.Instance.OnPlayerWin += HandleOnWin;
            GameManager.Instance.OnPlayerLose += HandleOnLose;
        }
    }
}