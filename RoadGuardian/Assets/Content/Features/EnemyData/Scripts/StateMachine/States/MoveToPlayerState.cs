using Content.Features.DamageableModule.Scripts;
using Content.Features.PlayerData.Scripts;
using UnityEngine;

namespace Content.Features.EnemyData.Scripts.StateMachine.States
{
    public class MoveToPlayerState : IState
    {
        private static readonly int s_onHit = Animator.StringToHash("OnHit");
        private static readonly int s_isMoving = Animator.StringToHash("IsMoving");
        public EnemyState Name { get; set; }

        private readonly EnemyStateMachine _enemyStateMachine;
        private readonly Animator _animator;
        private readonly Transform _playerTransform;
        private readonly Transform _enemyTransform;
        private readonly IEnemyDataService _enemyDataService;
        private readonly MonoDamageable _playerDamageable;
        
        public MoveToPlayerState(EnemyStateMachine enemyStateMachine, Animator animator,
            PlayerTransformModel playerTransformModel, Transform enemyTransform, IEnemyDataService enemyDataService,
            EnemyHealthModel enemyHealthModel)
        {
            _enemyStateMachine = enemyStateMachine;
            _animator = animator;
            _playerTransform = playerTransformModel.PlayerTransform;
            _enemyTransform = enemyTransform;
            _enemyDataService = enemyDataService;
            _playerDamageable = enemyHealthModel.EnemyDamagaeble;
        }

        public void Enter()
        {
            if (_animator != null) 
                _animator.SetBool(s_isMoving, true);
            
            _playerDamageable.OnDamaged += OnEnemyHit;
        }

        public void Exit()
        {
            if (_animator != null) 
                _animator.SetBool(s_isMoving, false);
            
            _playerDamageable.OnDamaged -= OnEnemyHit;
        }

        public void OnUpdate()
        {
            if (TryCatchPlayer()) 
                _enemyStateMachine.Enter<AttackPlayerState>();
        }

        private bool TryCatchPlayer()
        {
            Vector3 directionToPlayer = (_playerTransform.position - _enemyTransform.position).normalized;
            float distanceToPlayer = Vector3.Distance(_enemyTransform.position, _playerTransform.position);

            if (directionToPlayer != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
                _enemyTransform.rotation = Quaternion.Slerp(
                    _enemyTransform.rotation,
                    targetRotation,
                    _enemyDataService.GetEnemyData().RotationSpeed * Time.deltaTime
                );
            }

            if (!(distanceToPlayer > _enemyDataService.GetEnemyData().StoppingDistance)) return true;
            Vector3 newPosition = _enemyTransform.position +
                                  directionToPlayer * (_enemyDataService.GetEnemyData().MoveSpeed * Time.deltaTime);
            _enemyTransform.position = newPosition;
            
            return false;
        }
        
        private void OnEnemyHit() 
            => _animator.SetTrigger(s_onHit);
    }
}