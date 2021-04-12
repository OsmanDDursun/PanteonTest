using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonRemoteTest.Abstract.Movements
{
    public interface IObstacleMover
    {
        void MoveAction(float moveSpeed);
    }
}