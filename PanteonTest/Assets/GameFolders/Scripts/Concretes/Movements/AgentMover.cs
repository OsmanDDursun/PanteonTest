using PanteonRemoteTest.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace PanteonRemoteTest.Movements
{
    public class AgentMover
    {

        AgentController _agentController;
        NavMeshAgent _agent;

        public Vector3 Destination { get; private set; }

        public AgentMover(AgentController agentController)
        {
            _agentController = agentController;
            _agent = _agentController.GetComponent<NavMeshAgent>();
        }

        public void MoveTo(Vector3 destination)
        {
            _agent.isStopped = false;
            _agent.destination = destination;
            Destination = destination;
        }

        public void Move()
        {
            _agent.isStopped = false;
        }

        public void Stop()
        {
            _agent.isStopped = true;
        }

        public void SetDestination(Vector3 destination)
        {
            _agent.destination = destination;
            Destination = destination;
        }

        public void SetPos (Vector3 newPosition)
        {
            if (!_agent.Warp(newPosition)) _agent.transform.position = newPosition;
        }

    }
}