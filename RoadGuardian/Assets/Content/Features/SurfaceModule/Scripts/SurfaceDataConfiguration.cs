using UnityEngine;

namespace Content.Features.SurfaceModule.Scripts
{
    [CreateAssetMenu(menuName = "Configurations/Level/" + nameof(SurfaceDataConfiguration), 
        fileName = nameof(SurfaceDataConfiguration) + "_Default", order = 0)]
    public class SurfaceDataConfiguration : ScriptableObject
    {
        [SerializeField] private SurfaceData _surfaceData;
        
        public SurfaceData GetSurfaceData()
            => _surfaceData;
    }
}