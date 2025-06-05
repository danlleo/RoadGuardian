using System;
using UnityEngine;

namespace Content.Features.EnemyData.Scripts
{
    [Serializable]
    public class EnemyData
    {
        [field: SerializeField] public float MoveSpeed { get; set; } = 4f;
        [field: SerializeField] public float Damage { get; set; } = 1f;
        [field: SerializeField] public float StartHealth { get; set; } = 4f;
        [field: SerializeField] public float StoppingDistance { get; set; } = 1.5f;
        [field: SerializeField] public float RotationSpeed { get; set; } = 5f;
        [field: SerializeField] public float AttackDistance { get; set; } = 2.5f;
        [field: SerializeField] public float AttackDelay { get; set; } = 1.25f;
    }
}