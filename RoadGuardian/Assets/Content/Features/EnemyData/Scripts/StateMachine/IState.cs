namespace Content.Features.EnemyData.Scripts.StateMachine
{
    public interface IState : IExitableState
    {
        EnemyState Name { get; set; }
        void Enter();
    }

    public interface IPayloadState<TPayload> : IExitableState
    {
        void Enter(TPayload payload);
    }

    public interface IExitableState
    {
        void OnUpdate();
        void Exit();
    }
    
    public interface IUpdateableState : IState { }
}