namespace Content.Features.EnemyData.Scripts.StateMachine
{
    public interface IStateMachine
    {
        void Enter<TState>() where TState : class, IState;
    }
}