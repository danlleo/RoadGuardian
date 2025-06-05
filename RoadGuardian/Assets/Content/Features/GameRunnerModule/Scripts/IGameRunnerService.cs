using System;

namespace Content.Features.GameRunnerModule.Scripts
{
    public interface IGameRunnerService
    {
        event Action OnGameWon;
        event Action OnGameLost;
    }
}