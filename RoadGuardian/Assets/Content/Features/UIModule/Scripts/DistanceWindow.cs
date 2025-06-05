using Content.Features.GameTimerModule.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Content.Features.UIModule.Scripts
{
    [DisallowMultipleComponent]
    public class DistanceWindow : MonoBehaviour
    {
        [SerializeField] private Image _foreground;
        
        private IGameTimerService _gameTimerService;

        public void Construct(IGameTimerService gameTimerService) 
            => _gameTimerService = gameTimerService;

        private void Start() 
            => _gameTimerService.OnNormalizedTimerUpdated += SetNormalizedTimePassedValue;

        private void OnDestroy() 
            => _gameTimerService.OnNormalizedTimerUpdated -= SetNormalizedTimePassedValue;

        private void SetNormalizedTimePassedValue(float normalizedTime) 
            => _foreground.fillAmount = normalizedTime;
    }
}