using PanteonRemoteTest.Managers;
using PanteonRemoteTest.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace PanteonRemoteTest.Controllers
{
    public class AgentController : MonoBehaviour
    {

        Vector3 _startPos;
        bool _isFinish;
        bool _isResetting;
        bool _isGettingReady;
        bool _nextLevel;
        int _level = 0;

        Vector3 _firstDestination;
        Vector3 _lastDestination;

        NavMeshAgent _agent;
        AgentMover _agentMover;
        AgentAnimationController _agentAnimationController;


        private void Awake()
        {

            MaterialPropertyBlock materialBlock = new MaterialPropertyBlock();
            materialBlock.SetColor("_Color", Random.ColorHSV());
            SkinnedMeshRenderer renderer = GetComponentInChildren<SkinnedMeshRenderer>();
            renderer.SetPropertyBlock(materialBlock,0);

            _startPos = transform.position;
            _firstDestination = new Vector3 (Random.Range(-12f,12f), 0f, Random.Range(20f,30f));
            _lastDestination = new Vector3(0f, 0f, 220f);

            _agentAnimationController = new AgentAnimationController(this);
            _agentMover = new AgentMover(this);
            _agent = GetComponent<NavMeshAgent>();

            //Zorluk Ayarları
            _agent.stoppingDistance = Random.Range(0f, 4f);



        }

        private void Update()
        {
            _agentAnimationController.MoveAnimation(_agent.speed);
            if (GameManager.Instance.GameState != GameManager.GameStates.Prepare)
            {
                if (Vector3.Distance(_agentMover.Destination,transform.position) < 5)
                {
                    if (_agentMover.Destination == _lastDestination)
                    {
                        if (_isFinish) return;
                        _isFinish = true;
                        //Agent Kazanır Oyun Biter
                        _agentMover.Stop();
                        GameManager.Instance.PlayerLoseGame();
                        _agentAnimationController.PlayAnimation("Win");
                    }
                    else
                    {
                        _agentMover.SetDestination(LevelUp());
                    }
                }
            }
        }

        private void OnEnable()
        {
            GameManager.Instance.OnGameStart += HandleOnGameStart;
            GameManager.Instance.OnGameReady += HandleOnGameReady;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnGameStart -= HandleOnGameStart;
            GameManager.Instance.OnGameReady -= HandleOnGameReady;
        }

        Vector3 LevelUp()
        {
            _level++;
            Vector3 newDestination;
            if (_level >= GameManager.Instance.LevelConfig.Length)
            {
                newDestination = _lastDestination;
                //Debug.Log("FINISH");
            }
            else
            {
                newDestination = GameManager.Instance.LevelConfig[_level].ObstacleFinishPos;
                newDestination = new Vector3(Random.Range(-12f, 12f), 0f, newDestination.z);

                _agent.speed = GameManager.Instance.LevelConfig[_level].OpponentSpeed;
                _agent.obstacleAvoidanceType = GameManager.Instance.LevelConfig[_level].ObstacleAvoidance;
                
            }
            return newDestination;
        }

        private void HandleOnGameStart()
        {
            _agentMover.Move();
            _isGettingReady = false;
            _isFinish = false;
        }

        private void HandleOnGameReady()
        {
            _isGettingReady = true;
            _agentMover.SetPos(_startPos);
            _agentMover.Stop();
            transform.rotation = Quaternion.Euler(Vector3.zero);
            _agentMover.SetDestination(_firstDestination);
            _agentAnimationController.ResetAnimations();
            _level = 0;
        }

        public void HitObstacles()
        {
            if (_isResetting) return;
            _agentAnimationController.PlayAnimation("Fall");
            StartCoroutine(OnHitObstacle());
        }

        IEnumerator OnHitObstacle()
        {
            _level = 0;
            _isResetting = true;
            _agentMover.Stop();
            yield return new WaitForSeconds(1);
            if (!_isGettingReady)
            {
                _agentAnimationController.ResetAnimations();
                _agentMover.SetPos(_startPos);
                _agentMover.MoveTo(_firstDestination);
            }
            _isResetting = false;
        }

    }
}