using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace PanteonRemoteTest.ScriptableObjects
{
    [CreateAssetMenu(fileName = "new Data", menuName = "Create Data/Create New", order = 1)]
    public class GameData : ScriptableObject
    {

        [Header("Obstacles/Prefabs")]
        [SerializeField] GameObject[] _obstacles;
        [SerializeField] GameObject _coinPrefab;
        [SerializeField] Vector3 _obstacleFinishPos;


        [Header("AI")]
        [SerializeField] float _opponentSpeed = 10f;
        [SerializeField] ObstacleAvoidanceType _obstacleAvoidance; 


        public GameObject CoinPrefab => _coinPrefab;
        public GameObject[] Obstacles => _obstacles;
        public Vector3 ObstacleFinishPos => _obstacleFinishPos;
        public float OpponentSpeed => _opponentSpeed;
        public ObstacleAvoidanceType ObstacleAvoidance => _obstacleAvoidance;


    }
}