using PanteonRemoteTest.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconHolder : MonoBehaviour
{

    [SerializeField] Image _icon;

    private void Update()
    {
        if (GameManager.Instance.GameState == GameManager.GameStates.Playing)
        {
            Vector3 iconHolderPos = Camera.main.WorldToScreenPoint(transform.position);
            _icon.transform.position = iconHolderPos;
        }
    }
}
