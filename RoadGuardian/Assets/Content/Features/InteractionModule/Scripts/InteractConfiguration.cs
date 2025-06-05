﻿using UnityEngine;

namespace Content.Features.InteractionModule.Scripts
{
    [CreateAssetMenu(fileName = nameof(InteractConfiguration) + "_Default",
        menuName = "Configurations/InteractionModule/" + nameof(InteractConfiguration))]
    public class InteractConfiguration : ScriptableObject
    {
        [field: Header("Raycast")]
        [field: SerializeField]
        public int MaxHits { get; private set; } = 1;

        [field: SerializeField] public LayerMask PlayerInteractLayers { get; private set; }
    }
}