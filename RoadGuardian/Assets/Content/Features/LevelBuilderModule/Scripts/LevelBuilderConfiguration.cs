using UnityEngine;

namespace Content.Features.LevelBuilderModule.Scripts
{
    [CreateAssetMenu(menuName = "Configurations/Level/" + nameof(LevelBuilderConfiguration), 
        fileName = nameof(LevelBuilderConfiguration) + "_Default", order = 0)]
    public class LevelBuilderConfiguration : ScriptableObject
    {
        [SerializeField] private LevelBuilderData _levelBuilderData;
        
        public LevelBuilderData GetLevelBuilderData()
            => _levelBuilderData;
    }
}