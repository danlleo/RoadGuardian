using Content.Features.CameraModule.Scripts;
using Content.Features.GameTimerModule.Scripts;
using Content.Features.LevelBuilderModule.Scripts;
using Content.Features.PlayerData.Scripts;
using Content.Features.TurretModule.Scripts;

namespace Content.Features.GameFlowFacadeModule.Scripts
{
    public class GameFlowFacadeService : IGameFlowFacadeService
    {
        private readonly TurretTransformModel _turretTransformModel;
        private readonly PlayerTransformModel _playerTransformModel;
        private readonly LevelBuilder _levelBuilder;
        private readonly IGameTimerService _gameTimerService;
        private readonly PlayerCameraTransformModel _playerCameraTransformModel;

        public GameFlowFacadeService(TurretTransformModel turretTransformModel,
            PlayerTransformModel playerTransformModel, LevelBuilder levelBuilder, IGameTimerService gameTimerService,
            PlayerCameraTransformModel playerCameraTransformModel)
        {
            _turretTransformModel = turretTransformModel;
            _playerTransformModel = playerTransformModel;
            _levelBuilder = levelBuilder;
            _gameTimerService = gameTimerService;
            _playerCameraTransformModel = playerCameraTransformModel;
        }

        public void StartGame()
        {
            _levelBuilder.CreateLevel();
            _gameTimerService.RunTimer();
            _playerCameraTransformModel.PlayerCameraTransform.GetComponent<CinemachineCameraSetup>()
                .SetMoveCameraValues();
            _turretTransformModel.TurretTransform.GetComponent<TurretShootControl>().StartShooting();
            _playerTransformModel.PlayerTransform.GetComponent<MovePlayer>().StartMoving();
        }

        public void EndGame()
        {
            _turretTransformModel.TurretTransform.GetComponent<TurretShootControl>().StopShooting();
            _playerTransformModel.PlayerTransform.GetComponent<MovePlayer>().StopMoving();
            _gameTimerService.StopTimer();
        }
    }
}