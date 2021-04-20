using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonRemoteTest.Controllers
{
    public class ObstacleCollisionController : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (transform.CompareTag("RotatorStick"))
            {
                Vector3 dir = collision.contacts[0].point - collision.transform.position;
                dir = -dir.normalized;
                collision.transform.GetComponent<Rigidbody>().AddForceAtPosition(dir * 3000f, collision.contacts[0].point);
            }

            if (collision.transform.TryGetComponent(out PlayerController player))
            {
                player.HitObstacles();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.TryGetComponent(out AgentController agent))
            {
                agent.HitObstacles();
            }
        }
    }
}