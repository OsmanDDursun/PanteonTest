using PanteonRemoteTest.Inputs;
using PanteonRemoteTest.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonRemoteTest.Abstract.Controllers
{
    public abstract class AnimationController
    {
        protected Animator _animator;

        public Animator Animator => _animator;
        public virtual bool IsRunning { get; protected set; } 

        public void MoveAnimation(float moveSpeed)
        {
            _animator.SetFloat("AnimationSpeedMultiplier", moveSpeed / 8f);
            
            if(GameManager.Instance.GameState == GameManager.GameStates.Prepare)
            {
                _animator.SetBool("IsRunning", false);
            }
            else
            {
                _animator.SetBool("IsRunning", IsRunning);
            }
        }

        public void PlayAnimation(string anim)
        {
            _animator.SetTrigger(anim);
        }

        public void PlayAnimation(string anim, bool value)
        {
            if (_animator.GetBool(anim) == value) return;
            _animator.SetBool(anim,value);
        }

        protected void HandleOnWin()
        {
            PlayAnimation("Win");
        }

        protected void HandleOnLose()
        {
            PlayAnimation("Lose");
        }

        public void ResetAnimations()
        {
            _animator.Rebind();
            _animator.Update(0f);
        }

        public void ResetAnimation(string anim)
        {
            _animator.ResetTrigger(anim);
        }
    }
}