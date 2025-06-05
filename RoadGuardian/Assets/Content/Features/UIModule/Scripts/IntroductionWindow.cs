using DG.Tweening;
using UnityEngine;

namespace Content.Features.UIModule.Scripts
{
    [DisallowMultipleComponent]
    public class IntroductionWindow : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _backgroundAlpha;
        [SerializeField] private CanvasGroup _introductionTextAlpha;
        [SerializeField] private CanvasGroup _logoAlpha;

        private void Start() 
            => BlinkIntroductionText();

        public void Hide()
        {
            _backgroundAlpha.DOFade(0f, 0.3f).SetEase(Ease.OutBounce);
            _logoAlpha.DOFade(0f, 0.3f).SetEase(Ease.OutBounce);
            
            _introductionTextAlpha.DOKill();
            _introductionTextAlpha.DOFade(0f, 0.3f).SetEase(Ease.OutBounce);
        }

        private void BlinkIntroductionText()
        {
            _introductionTextAlpha.DOFade(0f, 0.6f)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.InOutSine);
        }
    }
}