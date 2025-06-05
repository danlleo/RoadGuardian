using Content.Features.DamageableModule.Scripts;
using Content.Features.PlayerData.Scripts;
using Content.Features.TriggerObserverModule.Scripts;
using UnityEngine;

namespace Content.Features.EnemyData.Scripts.StateMachine.States
{
    public class IdleState : IState
    {
        private static readonly int s_onHit = Animator.StringToHash("OnHit");
        public EnemyState Name { get; set; }
        
        private readonly EnemyStateMachine _stateMachine;
        private readonly TriggerObserver _triggerObserver;
        private readonly MonoDamageable _playerDamageable;
        private readonly Animator _animator;
        
        public IdleState(EnemyStateMachine stateMachine, TriggerObserver triggerObserver,
            EnemyHealthModel enemyHealthModel, Animator animator)
        {
            _stateMachine = stateMachine;
            _triggerObserver = triggerObserver;
            _playerDamageable = enemyHealthModel.EnemyDamagaeble;
            _animator = animator;
        }

        public void Enter()
        {
            _triggerObserver.TriggerEnter += TryAggroOnPlayer;
            _playerDamageable.OnDamaged += OnEnemyHit;
        }

        public void Exit()
        {
            _triggerObserver.TriggerEnter -= TryAggroOnPlayer;
            _playerDamageable.OnDamaged -= OnEnemyHit;
        }

        public void OnUpdate() { }

        private void TryAggroOnPlayer(Collider collider)
        {
            if (!collider.TryGetComponent(out PlayerMarker _)) return;
            _stateMachine.Enter<MoveToPlayerState>();
        }

        private void OnEnemyHit() 
            => _animator.SetTrigger(s_onHit);
    }
}