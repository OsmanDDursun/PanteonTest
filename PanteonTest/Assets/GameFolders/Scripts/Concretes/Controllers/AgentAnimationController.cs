using PanteonRemoteTest.Abstract.Controllers;
using PanteonRemoteTest.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace PanteonRemoteTest.Controllers
{
    public class AgentAnimationController : AnimationController
    {
        NavMeshAgent _agent;
        AgentController _agentController;

        public override bool IsRunning => !_agent.isStopped;

        public AgentAnimationController(AgentController agentController)
        {
            _agentController = agentController;

            _agent = _agentController.GetComponent<NavMeshAgent>();
            _animator = _agentController.GetComponentInChildren<Animator>();
        }
    }
}
