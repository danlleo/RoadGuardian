using System;
using System.Collections.Generic;
using Content.Features.EnemyData.Scripts.StateMachine.States;
using Content.Features.PlayerData.Scripts;
using Content.Features.TriggerObserverModule.Scripts;
using Content.Global.Scripts;
using UnityEngine;

namespace Content.Features.EnemyData.Scripts.StateMachine
{
    public class EnemyStateMachine : IStateMachine
    {
        public EnemyState CurrentState { get; private set; }

        public Action<EnemyState> StateEntered;
        public Action<EnemyState> StateExited;
        
        private Dictionary<Type, IState> _phaseStates;
        private IState _activeState;
        
        private bool _isActive = true;

        public EnemyStateMachine(TriggerObserver triggerObserver, Animator animator,
            PlayerTransformModel playerTransformModel, Transform enemyTransform, IEnemyDataService enemyDataService,
            ICoroutineRunner coroutineRunner, PlayerHealthModel playerHealthModel, EnemyHealthModel enemyHealthModel)
        {
            _phaseStates = new Dictionary<Type, IState>
            {
                [typeof(IdleState)] = new IdleState(this, triggerObserver, enemyHealthModel, animator),
                [typeof(MoveToPlayerState)] =
                    new MoveToPlayerState(this, animator, playerTransformModel, enemyTransform, enemyDataService, enemyHealthModel),
                [typeof(AttackPlayerState)] = new AttackPlayerState(animator, enemyDataService, playerTransformModel,
                    coroutineRunner, enemyTransform, playerHealthModel, enemyHealthModel),
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            if (!_isActive)
                return;

            IState state = ChangeState<TState>();
            state.Enter();
            CurrentState = state.Name;
            StateEntered?.Invoke(CurrentState);
        }
        
        public void Update() 
            => _activeState?.OnUpdate();

        public void Deactivate() 
            => _isActive = false;
        
        private TState ChangeState<TState>() where TState : class, IState
        {
            _activeState?.Exit();
            StateExited?.Invoke(CurrentState);
            TState state = GetState<TState>();
            _activeState = state;
            return state;
        }

        private TState GetState<TState>() where TState : class, IState =>
            _phaseStates[typeof(TState)] as TState;
    }
}