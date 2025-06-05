using Content.Global.Scripts;
using UnityEngine;
using UnityEngine.AI;

namespace Content.Features.EnemyData.Scripts
{
    public class AgentMoveToPlayer : Follow
    {
        public NavMeshAgent Agent;

        private const float MinimalDistance = 1;

        private Transform _heroTransform;

        public void Construct(Transform heroTransform) =>
            _heroTransform = heroTransform;

        private void Update()
        {
            if (_heroTransform && IsHeroNotReached())
                Agent.destination = _heroTransform.position;
        }

        private bool IsHeroNotReached() 
            => Agent.transform.position.SqrMagnitudeTo(_heroTransform.position) >= MinimalDistance;
    }
}