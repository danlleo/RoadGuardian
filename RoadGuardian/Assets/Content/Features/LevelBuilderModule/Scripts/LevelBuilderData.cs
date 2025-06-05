using System;
using UnityEngine;

namespace Content.Features.LevelBuilderModule.Scripts
{
    [Serializable]
    public class LevelBuilderData
    {
        [field: SerializeField] public float TotalLevelTimeDuration { get; private set; } = 40f;
        [field: SerializeField] public int InitialFreeSurfacesAmount { get; private set; } = 2;
        [field: SerializeField] public int EnemyFilledSurfacesAmount { get; private set; } = 10;
        [field: SerializeField] public float PlaceOffset { get; set; } = 105f;
    }
}