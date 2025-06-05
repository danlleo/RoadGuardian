using Content.Features.DamageableModule.Scripts;
using Content.Features.PlayerData.Scripts;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Content.Features.UIModule.Scripts
{
    [DisallowMultipleComponent]
    public class PlayerHealthBarWindow : MonoBehaviour
    {
        [SerializeField] private Image _foreground;
        
        private MonoDamageable _playerDamageable;
        
        [Inject]
        public void InjectDependencies(PlayerHealthModel playerHealthModel) 
            => _playerDamageable = playerHealthModel.PlayerDamageable;

        private void Start()
        {
            SetNormalizedHealthPercentValue(_playerDamageable.GetNormalizedHealthValue());
            _playerDamageable.OnNormalizedHealthPercentChanged += SetNormalizedHealthPercentValue;
        }

        private void OnDestroy() 
            => _playerDamageable.OnNormalizedHealthPercentChanged += SetNormalizedHealthPercentValue;
        
        private void SetNormalizedHealthPercentValue(float normalizedHealthPercent) 
            => _foreground.fillAmount = normalizedHealthPercent;
    }
}