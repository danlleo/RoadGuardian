using System;
using UnityEngine;

namespace Content.Features.SurfaceModule.Scripts
{
    [Serializable]
    public class SurfaceData
    {
        [field: SerializeField, Range(1, 10)] public int MaxAmountOfProbableEnemies { get; private set; } = 1;
    }
}