using System;

namespace Content.Features.TurretModule.Scripts
{
    public interface ITurretInput
    {
        event Action<float> OnTurretDeltaUpdated;
    }
}