using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Superplay.UI.ProgressBar
{
    [RequireComponent(typeof(CanvasGroup))]
    public class ProgressBarBonusItemComponent : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup canvasGroup;
        
        [SerializeField]
        private Image bonusItemImage;
        
        [SerializeField]
        private TextMeshProUGUI bonusItemCounter;
        
        [SerializeField]
        private Image glowImage;

        private Sequence _sequence;

        public void Initialize()
        {
            
        }
        
        public void Dismiss()
        {
            
        }

        public void Show()
        {
            canvasGroup.DOFade(1f, 0.5f);
        }
        
        public void Hide()
        {
            canvasGroup.DOFade(0f, 0.35f);
        }

        public void UpdateBonusItem(BonusItemTypes type, int count)
        {
            bonusItemCounter.text = $"{count}";
            
            glowImage.transform.DORotate( Vector3.forward * 360f, 4f, RotateMode.LocalAxisAdd).SetEase(Ease.Linear).SetLoops(-1);

            if (_sequence != null && _sequence.IsPlaying())
            {
                _sequence.Kill(true);
            }
            
            _sequence = DOTween.Sequence();
            _sequence.Append(bonusItemImage.transform.DOPunchScale(Vector3.one * 0.15f, 0.35f, 4, 0.5f));
            _sequence.AppendInterval(2.5f);
            _sequence.Join(bonusItemImage.transform.DOShakePosition(1.5f, 6f, 3));
            _sequence.Join(bonusItemImage.transform.DOShakeRotation(1.5f, Vector3.forward * 6f, 3));
        }
    }
}