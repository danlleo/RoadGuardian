using System;
using UnityEngine;

namespace Content.Features.PlayerData.Scripts
{
    [Serializable]
    public class PlayerData
    {
        [field: SerializeField] public float StartHealth { get; private set; } = 10f;
        [field: SerializeField] public float MovingSpeed { get; private set; } = 10f;
    } 
}