using PanteonRemoteTest.Inputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonRemoteTest.Controllers
{
    public class AnimationController
    {
        Animator _animator;
        PlayerController _playerController;

        public AnimationController(PlayerController playerController)
        {
            _playerController = playerController;
            _animator = _playerController.GetComponentInChildren<Animator>();
        }

        public void MoveAnimation(float moveSpeed)
        {
            if (_animator.GetFloat("MoveSpeed") == moveSpeed) return;
            _animator.SetFloat("MoveSpeed", moveSpeed, 0.1f, Time.deltaTime);
        }

    }
}