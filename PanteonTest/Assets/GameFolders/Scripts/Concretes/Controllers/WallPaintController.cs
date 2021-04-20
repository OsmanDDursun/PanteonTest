using PanteonRemoteTest.Inputs;
using PanteonRemoteTest.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonRemoteTest.Controllers
{
    public class WallPaintController : MonoBehaviour
    {

        [SerializeField] GameObject _rollerBrush;
        [SerializeField] GameObject _brushPattern;
        [SerializeField] Camera _paintCamera;
        [SerializeField] Camera _sceneCamera;
        [SerializeField] GameObject _brushContainer;
        [SerializeField] RenderTexture _renderTexture;
        [SerializeField] Material _baseMaterial;
        [SerializeField] Color _brushColor = Color.red;

        InputReader _input;
        Transform _roller;
        bool _isSaving;
        Vector3 _oldPos;

        public Color BrushColor => _brushColor;

        private void Awake()
        {
            _roller = _rollerBrush.transform.GetChild(0);
            _input = GetComponent<InputReader>();
        }

        private void Update()
        {
            if (GameManager.Instance.GameState == GameManager.GameStates.PaintingGame)
            {
                Vector3 inputPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _rollerBrush.transform.position.z - _sceneCamera.transform.position.z);
                Vector3 worldPosition = _sceneCamera.ScreenToWorldPoint(inputPos);
                _rollerBrush.transform.position = worldPosition;

                if (_input.IsPainting) DoPaint();

                if (Input.GetKey(KeyCode.A))
                {
                    //SaveTexture();
                    Debug.Log(_input.IsPainting);
                    //Debug.Log(ApproximatelyColor(new Color(0.974f, 0.125f, 0.080f), Color.red));
                }
            }
        }

        private void OnEnable()
        {
            GameManager.Instance.OnPaintingGameStart += HandleOnPaintStart;
            GameManager.Instance.OnGameReady += HandleOnGameReady;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnPaintingGameStart -= HandleOnPaintStart;
            GameManager.Instance.OnGameReady -= HandleOnGameReady;
        }

        private void HandleOnGameReady()
        {
            _rollerBrush.SetActive(false);
            foreach (Transform child in _brushContainer.transform)
            {
                Destroy(child.gameObject);
            }
        }

        private void HandleOnPaintStart()
        {
            _rollerBrush.SetActive(true);
        }

        void DoPaint()
        {
            if (_isSaving) return;
            Vector3 uvWorldPosition = Vector3.zero;
            if (HitUVPosition(ref uvWorldPosition))
            {
                if (uvWorldPosition == _oldPos) return;
                GameObject brushPatternOBJ = Instantiate(_brushPattern);
                brushPatternOBJ.GetComponent<SpriteRenderer>().color = _brushColor;
                brushPatternOBJ.transform.parent = _brushContainer.transform;
                brushPatternOBJ.transform.localPosition = uvWorldPosition;
                brushPatternOBJ.transform.localScale *= 0.1f;
                brushPatternOBJ.transform.rotation = _rollerBrush.transform.rotation;
                _oldPos = uvWorldPosition;
            }
        }

        bool HitUVPosition(ref Vector3 uvWorldPosition)
        {
            RaycastHit hit;
            Ray ray = new Ray(_roller.transform.position, Vector3.forward);
            if (Physics.Raycast(ray, out hit))
            {
                MeshCollider meshCollider = hit.collider as MeshCollider;
                if (meshCollider == null || meshCollider.sharedMesh == null)
                    return false;
                Vector2 pixelUV = hit.textureCoord;
                uvWorldPosition.x = pixelUV.x - _paintCamera.orthographicSize;
                uvWorldPosition.y = pixelUV.y - _paintCamera.orthographicSize;
                uvWorldPosition.z = 0.0f;
                return true;
            }
            else
            {
                return false;
            }

        }

        public int GetPaintPercent()
        {
            Texture2D tex = GetTexture2D(_renderTexture);
            int baseColorPixels = tex.width * tex.height;
            int paintColorPixels = 0;
            Color[] cols = tex.GetPixels(0, 0, tex.width, tex.height);
            foreach (Color col in cols)
            {
                if(ApproximatelyColor(col,_brushColor,100))
                paintColorPixels++;
            }
            if (baseColorPixels == 0) return 0;
            int percent = Mathf.FloorToInt((float)paintColorPixels / (float)baseColorPixels * 100f);
            if (Mathf.Abs(percent - 100) < 1.5f) percent = 100;
            Destroy(tex);
            return percent;
        }

        Texture2D GetTexture2D(RenderTexture rt)
        {
            RenderTexture.active = rt;
            Texture2D tex = new Texture2D(rt.width, rt.height);
            tex.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
            tex.Apply();
            RenderTexture.active = null;
            return tex;
        }

        bool ApproximatelyColor(Color color1, Color color2, int delta = 70)
        {
            float r1 = color1.r * 1000;
            float g1 = color1.g * 1000;
            float b1 = color1.b * 1000;

            float r2 = color2.r * 1000;
            float g2 = color2.g * 1000;
            float b2 = color2.b * 1000;


            if ((Mathf.Abs(r1 - r2) < delta) && (Mathf.Abs(g1 - g2) < delta) && (Mathf.Abs(b1 - b2) < delta))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}