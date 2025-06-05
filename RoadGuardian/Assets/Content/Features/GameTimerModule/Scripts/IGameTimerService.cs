using System;

namespace Content.Features.GameTimerModule.Scripts
{
    public interface IGameTimerService
    {
        event Action OnTimerStarted;
        event Action OnTimerStopped;
        event Action<float> OnNormalizedTimerUpdated;
        event Action OnTimerEnd;
        void RunTimer();
        void StopTimer();
    }
}