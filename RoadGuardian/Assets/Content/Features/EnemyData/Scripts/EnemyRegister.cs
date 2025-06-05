using Content.Features.DamageableModule.Scripts;
using Content.Features.EnemyData.Scripts.StateMachine;
using Content.Features.EnemyData.Scripts.StateMachine.States;
using Content.Features.PlayerData.Scripts;
using Content.Features.TriggerObserverModule.Scripts;
using Content.Global.Scripts;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Content.Features.EnemyData.Scripts
{
    [SelectionBase]
    [DisallowMultipleComponent]
    public class EnemyRegister : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private TriggerObserver _triggerObserver;
        
        private EnemyStateMachine _stateMachine;
        private PlayerTransformModel _playerTransformModel;
        private IEnemyDataService _enemyDataService;
        private EnemyHealthModel _enemyHealthModel;
        private ICoroutineRunner _coroutineRunner;
        private PlayerHealthModel _playerHealthModel;

        [Inject]
        public void InjectDependencies(PlayerTransformModel playerTransformModel, ICoroutineRunner coroutineRunner,
            PlayerHealthModel playerHealthModel)
        {
            _playerTransformModel = playerTransformModel;
            _coroutineRunner = coroutineRunner;
            _playerHealthModel = playerHealthModel;
        }

        public void Construct(IEnemyDataService enemyDataService, EnemyHealthModel enemyHealthModel)
        {
            _enemyDataService = enemyDataService;
            _enemyHealthModel = enemyHealthModel;
        }

        private void Awake()
        {
            SetRandomRotation();
        }

        private void Start()
        {
            _enemyHealthModel.InitializeHealth(GetComponent<MonoDamageable>(),
                _enemyDataService.GetEnemyData().StartHealth);
            
            InitializeStateMachine();
            _stateMachine.Enter<IdleState>();
        }

        private void Update() 
            => _stateMachine.Update();

        private void InitializeStateMachine()
        {
            _stateMachine = new EnemyStateMachine(_triggerObserver, _animator, _playerTransformModel, transform,
                _enemyDataService, _coroutineRunner, _playerHealthModel, _enemyHealthModel);
        }

        private void SetRandomRotation()
        {
            float randomYRotation = Random.Range(0f, 360f);
            transform.rotation = Quaternion.Euler(0f, randomYRotation, 0f);
        }
    }
}