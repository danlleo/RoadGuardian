using System.Collections.Generic;
using Core.StateMachineModule.Scripts;

namespace Content.Features.GameFlowStateMachineModule.Scripts
{
    public class GameFlowStateMachine : StateMachineBehaviour<GameFlowStateBase>
    {
        public GameFlowStateMachine(GlobalGameFlowState bootstrapGameFlowState,
            EnterMainFlowState enterMainFlowState) =>
            SetStates(new List<GameFlowStateBase>
            {
                bootstrapGameFlowState, enterMainFlowState
            });
    }
}