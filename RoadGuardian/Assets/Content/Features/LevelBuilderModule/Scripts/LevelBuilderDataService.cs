namespace Content.Features.LevelBuilderModule.Scripts
{
    public class LevelBuilderDataService : ILevelBuilderDataService
    {
        private readonly LevelBuilderConfiguration _levelBuilderConfiguration;

        public LevelBuilderDataService(LevelBuilderConfiguration levelBuilderConfiguration) 
            => _levelBuilderConfiguration = levelBuilderConfiguration;
        
        public LevelBuilderData GetLevelBuilderConfiguration() 
            => _levelBuilderConfiguration.GetLevelBuilderData();
    }
}