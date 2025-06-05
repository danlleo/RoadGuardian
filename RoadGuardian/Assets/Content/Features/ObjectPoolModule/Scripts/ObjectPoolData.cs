using System;
using UnityEngine;

namespace Content.Features.ObjectPoolModule.Scripts
{
    [Serializable]
    public class ObjectPoolData
    {
        public string PoolId;
        public GameObject Prefab;
        public int InitialSize = 10;
        public Transform Parent;
    }
}