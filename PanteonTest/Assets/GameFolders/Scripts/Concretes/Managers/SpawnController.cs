using PanteonRemoteTest.Abstract.Managers;
using PanteonRemoteTest.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonRemoteTest.Managers
{
    public class SpawnController : MonoBehaviour
    {
        List<GameObject> _levelObjects;
        private void Awake()
        {
            _levelObjects = new List<GameObject>();
        }

        private void Start()
        {
        }

        public void CreateGameArea()
        {
            Vector3 startPos = new Vector3(0, 0, 20);
            Vector3 newPos = startPos;
            GameObject obstackle;
            Vector3 zPosIncrease = new Vector3(0f, 0f, 15f);
            float obstacleCount = 0;
            float coinCount = 0;
            float maxCoinCount = Random.Range(4, 7);
            float coinBetween = Random.Range(3, 5);
            if (_levelObjects.Count != 0)
            {
                for (int i = 0; i < _levelObjects.Count; i++)
                {
                    Destroy(_levelObjects[i]);
                }
                _levelObjects.Clear();
            }
            for (int i = 0; i < GameManager.Instance.LevelConfig.Length; i++)
            {
                GameData levelData = GameManager.Instance.LevelConfig[i];
                GameObject coin = levelData.CoinPrefab;
                GameObject[] obstackles = levelData.Obstacles;
                Vector3 obstacleFinishPos = levelData.ObstacleFinishPos;

                while (true)
                {
                    obstackle = obstackles[Random.Range(0, obstackles.Length)];
                    
                    if (obstacleCount >= coinBetween && coinCount < maxCoinCount)
                    {
                        Vector3 oldPos = newPos;
                        newPos = new Vector3(Random.Range(-10, 10), newPos.y, newPos.z);
                        GameObject newCoin = Instantiate(coin, newPos, coin.transform.rotation);
                        newPos = oldPos;
                        obstacleCount = 0;
                        coinCount++;
                        _levelObjects.Add(newCoin);
                    }
                    else
                    {
                        GameObject newObstacle = Instantiate(obstackle, newPos, coin.transform.rotation);
                        _levelObjects.Add(newObstacle);
                        obstacleCount++;
                    }
                    newPos += zPosIncrease;
                    if (Vector3.Distance(newPos, obstacleFinishPos) < zPosIncrease.z) break;
                }
            }

        }

        internal void CreateScene()
        {
            CreateGameArea();
        }
    }
}