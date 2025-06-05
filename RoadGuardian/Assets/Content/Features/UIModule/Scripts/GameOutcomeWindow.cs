using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Content.Features.UIModule.Scripts
{
    [DisallowMultipleComponent]
    public class GameOutcomeWindow : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _backgroundCanvasGroup;
        [SerializeField] private CanvasGroup _textCanvasGroup;
        [SerializeField] private CanvasGroup _proceedTextCanvasGroup;
        [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
        
        public void Display(bool hasWon)
        {
            _textMeshProUGUI.text = hasWon ? "You won!" : "You lost..";

            _textCanvasGroup.alpha = 0f;
            Vector3 originalPos = _textCanvasGroup.transform.localPosition;
            _textCanvasGroup.transform.localPosition = originalPos + new Vector3(0f, 30f, 0f);

            _backgroundCanvasGroup.DOFade(0.35f, 0.5f).OnComplete(() =>
            {
                Sequence textSequence = DOTween.Sequence();
                textSequence.Append(_textCanvasGroup.DOFade(1f, 0.5f));
                textSequence.Join(_textCanvasGroup.transform.DOLocalMoveY(originalPos.y, 0.5f).SetEase(Ease.OutQuad));
            });

            _proceedTextCanvasGroup.DOFade(0.35f, 0.5f).OnComplete(() =>
            {
                _proceedTextCanvasGroup.DOFade(0f, 0.6f)
                    .SetLoops(-1, LoopType.Yoyo)
                    .SetEase(Ease.InOutSine);
            });
        }
    }
}
