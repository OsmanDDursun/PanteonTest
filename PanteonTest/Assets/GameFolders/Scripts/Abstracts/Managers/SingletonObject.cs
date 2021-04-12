using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonRemoteTest.Abstract.Managers {
    public abstract class SingletonObject<T> : MonoBehaviour
    {
        public static T Instance { get; private set; }

        protected void MakeThisSingleton(T entity)
        {
            if (Instance == null)
            {
                Instance = entity;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

    }
}