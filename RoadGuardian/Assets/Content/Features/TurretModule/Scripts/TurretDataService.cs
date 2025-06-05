namespace Content.Features.TurretModule.Scripts
{
    public class TurretDataService : ITurretDataService
    {
        private readonly TurretDataConfiguration _turretDataConfiguration;

        public TurretDataService(TurretDataConfiguration turretDataConfiguration) 
            => _turretDataConfiguration = turretDataConfiguration;

        public TurretData GetTurretData() 
            => _turretDataConfiguration.GetTurretData();
    }
}