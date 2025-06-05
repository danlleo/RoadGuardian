using System.Collections;
using UnityEngine;
using Zenject;

namespace Content.Features.PlayerData.Scripts
{
    [DisallowMultipleComponent]
    public class MovePlayer : MonoBehaviour
    {
        private float _movingSpeed;
        private Coroutine _movingRoutine;
        
        [Inject]
        public void InjectDependencies(PlayerDataConfiguration playerDataConfiguration) 
            => _movingSpeed = playerDataConfiguration.GetPlayerData().MovingSpeed;

        public void StartMoving() 
            => _movingRoutine ??= StartCoroutine(MovingRoutine());

        public void StopMoving()
        {
            if (_movingRoutine != null)
                StopCoroutine(_movingRoutine);
        }

        private IEnumerator MovingRoutine()
        {
            while (true)
            {
                transform.Translate(Vector3.forward * (_movingSpeed * Time.deltaTime));
                yield return null;
            }
        }
    }
}