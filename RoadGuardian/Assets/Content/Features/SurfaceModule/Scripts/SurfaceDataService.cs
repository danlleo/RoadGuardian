namespace Content.Features.SurfaceModule.Scripts
{
    public class SurfaceDataService : ISurfaceDataService
    {
        private readonly SurfaceDataConfiguration _surfaceDataConfiguration;

        public SurfaceDataService(SurfaceDataConfiguration surfaceDataConfiguration) 
            => _surfaceDataConfiguration = surfaceDataConfiguration;

        public SurfaceData GetSurfaceData() 
            => _surfaceDataConfiguration.GetSurfaceData();
    }
}