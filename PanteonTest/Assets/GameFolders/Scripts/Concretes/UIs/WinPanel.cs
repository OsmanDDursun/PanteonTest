using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PanteonRemoteTest.Managers;

namespace PanteonRemoteTest.UIs
{
    public class WinPanel : MonoBehaviour
    {
        [SerializeField] TMP_Text _scoreText;

        private void OnEnable()
        {
            if (GameManager.Instance.GameState == GameManager.GameStates.PaintingGameFinish)
                _scoreText.text = "100";
            else
                _scoreText.text = ScoreManager.Instance.CurrentScore.ToString();

        }

    }
}