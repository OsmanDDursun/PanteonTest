using PanteonRemoteTest.Abstract.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonRemoteTest.Managers
{
    public class SpawnManager : SingletonObject<SpawnManager>
    {
        private void Awake()
        {
            MakeThisSingleton(this);
        }
    }
}