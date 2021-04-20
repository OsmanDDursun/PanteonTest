using PanteonRemoteTest.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PanteonRemoteTest.Inputs;
using PanteonRemoteTest.Managers;

namespace PanteonRemoteTest.UIs
{
    public class PaintProgressBarController : MonoBehaviour
    {
        WallPaintController _wallPaintController;
        InputReader _input;
        [SerializeField] Image _progressBar;
        [SerializeField] TMP_Text _percentText;

        bool _paintDone;
        private void Awake()
        {
            _wallPaintController = FindObjectOfType<WallPaintController>();
            _input = FindObjectOfType<InputReader>();
        }

        private void OnEnable()
        {
            _paintDone = false;
            StartCoroutine(SetProgressBar());
        }

        IEnumerator SetProgressBar()
        {
            while (!_paintDone)
            {
                yield return new WaitForSeconds(1);
                if (_input.IsPainting)
                {
                    int percent = _wallPaintController.GetPaintPercent();
                    _progressBar.fillAmount = percent / 100f;
                    _percentText.text = $"% {percent}";
                    if (percent == 100) { 
                        _paintDone = true;
                        GameManager.Instance.PaintDone();
                        _progressBar.fillAmount = 0;
                    }
                }
            }
        }
    }
}