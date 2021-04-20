using PanteonRemoteTest.Abstract.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonRemoteTest.Managers
{
    public class SoundManager : SingletonObject<SoundManager>
    {
        AudioSource[] _audioSources;
        bool _isSoundOff;

        const int MENU_SOUND = 0;
        const int GAMING_SOUND = 1;
        const int GAIN_COIN_SOUND = 2;
        const int WIN_SOUND = 3;
        const int LOSE_SOUND = 4;
        const int GO_PAINT = 5;

        public bool IsSoundOff => _isSoundOff;

        private void Awake()
        {
            MakeThisSingleton(this);
            _audioSources = GetComponentsInChildren<AudioSource>();
        }

        private void OnEnable()
        {
            GameManager.Instance.OnGameReady += HandleOnGameReady;
            GameManager.Instance.OnGameStart += HandleOnGameStart;
            GameManager.Instance.OnPlayerWin += HandleOnWin;
            GameManager.Instance.OnPaintDone += HandleOnWin;
            GameManager.Instance.OnPlayerLose += HandleOnLose;
            GameManager.Instance.OnPaintingGameReady += HandleOnPaintGameReady;
            ScoreManager.Instance.OnScoreGain += HandleOnGainCoin;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnGameReady -= HandleOnGameReady;
            GameManager.Instance.OnGameStart -= HandleOnGameStart;
            GameManager.Instance.OnPlayerWin -= HandleOnWin;
            GameManager.Instance.OnPaintDone -= HandleOnWin;
            GameManager.Instance.OnPlayerLose -= HandleOnLose;
            ScoreManager.Instance.OnScoreGain -= HandleOnGainCoin;
            GameManager.Instance.OnPaintingGameReady -= HandleOnPaintGameReady;
        }

        public void SoundOnOff()
        {
            _isSoundOff = !_isSoundOff;
            for (int i = 0; i < _audioSources.Length; i++)
            {
                _audioSources[i].mute = _isSoundOff;
            }
        }

        public void PlaySound(int index, bool isLooping = false)
        {
            if (!_audioSources[index].isPlaying)
            {
                _audioSources[index].loop = isLooping;
                _audioSources[index].Play();
            }
        }
        public void PlaySoundAlways(int index)
        {   
                _audioSources[index].Play();
        }

        public void StopSound(int index)
        {
            if (_audioSources[index].isPlaying)
            {
                _audioSources[index].Stop();
            }
        }

        private void HandleOnGameStart()
        {
            PlaySingleSound(GAMING_SOUND, true);
        }
        private void HandleOnGameReady()
        {
            PlaySingleSound(MENU_SOUND, true);
        }
        private void HandleOnGainCoin()
        {
            PlaySoundAlways(GAIN_COIN_SOUND);
        }
        private void HandleOnWin()
        {
            PlaySingleSound(WIN_SOUND);
        }
        private void HandleOnLose()
        {
            PlaySingleSound(LOSE_SOUND);
        }
        private void HandleOnPaintGameReady()
        {
            PlaySingleSound(GO_PAINT);
        }

        void PlaySingleSound(int index, bool isLooping = false)
        {
            for (int i = 0; i < _audioSources.Length; i++)
            {
                if (index == i) { PlaySound(index, isLooping);  continue; }
                StopSound(i);
            }
        }
    }
}


