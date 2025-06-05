using System.Collections;
using Content.Features.DamageableModule.Scripts;
using Content.Features.PlayerData.Scripts;
using Content.Global.Scripts;
using UnityEngine;

namespace Content.Features.EnemyData.Scripts.StateMachine.States
{
    public class AttackPlayerState : IState
    {
        private static readonly int s_onHit = Animator.StringToHash("OnHit");
        private static readonly int s_onAttack = Animator.StringToHash("OnAttack");
        public EnemyState Name { get; set; }

        private readonly Animator _animator;
        private readonly IEnemyDataService _enemyDataService;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly Transform _enemyTransform;
        private readonly Transform _playerTransform;
        private readonly PlayerHealthModel _playerHealthModel;
        private readonly MonoDamageable _playerDamageable;
        
        public AttackPlayerState(Animator animator, IEnemyDataService enemyDataService,
            PlayerTransformModel playerTransformModel, ICoroutineRunner coroutineRunner, Transform enemyTransform,
            PlayerHealthModel playerHealthModel, EnemyHealthModel enemyHealthModel)
        {
            _animator = animator;
            _enemyDataService = enemyDataService;
            _coroutineRunner = coroutineRunner;
            _enemyTransform = enemyTransform;
            _playerTransform = playerTransformModel.PlayerTransform;
            _playerHealthModel = playerHealthModel;
            _playerDamageable = enemyHealthModel.EnemyDamagaeble;
        }

        public void Enter()
        {
            _coroutineRunner.StartCoroutine(AttackRoutine());
            _playerDamageable.OnDamaged += OnEnemyHit;
        }

        public void Exit()
        {
            _playerDamageable.OnDamaged -= OnEnemyHit;
        }

        public void OnUpdate() { }

        private void OnEnemyHit() 
            => _animator.SetTrigger(s_onHit);
        
        private IEnumerator AttackRoutine()
        {
            while (true)
            {
                if (_enemyTransform == null || _playerTransform == null)
                    yield break;
                
                float distanceToPlayer = Vector3.Distance(_enemyTransform.position, _playerTransform.position);
                float attackRange = _enemyDataService.GetEnemyData().AttackDistance;

                if (distanceToPlayer > attackRange)
                    yield break;

                if (_animator != null) 
                    _animator.SetTrigger(s_onAttack);

                _playerHealthModel.PlayerDamageable.Damage(_enemyDataService.GetEnemyData().Damage);
                yield return new WaitForSeconds(_enemyDataService.GetEnemyData().AttackDelay);
            }
        }
    }
}