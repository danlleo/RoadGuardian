using System;
using UnityEngine;

namespace Content.Features.TurretModule.Scripts
{
    [Serializable]
    public class TurretData
    {
        [field: SerializeField] public float BulletDamage { get; private set; } = 1f;
        [field: SerializeField] public float BulletSpeed { get; private set; } = 1f;
        [field: SerializeField] public float FireRate { get; private set; } = 0.2f;
        [field: SerializeField] public float DisposeBulletTime { get; private set; } = 1f;
    }
}