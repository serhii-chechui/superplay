using DG.Tweening;
using Superplay.UI.Widget;
using UnityEngine;
using UnityEngine.UI;

namespace Superplay.UI.Popup
{
    public class PopupWidget : UIWidget
    {
        [SerializeField]
        private Button claimButton;

        [SerializeField]
        private Image shroudImage;

        public void Initialize(PopupWidgetData data)
        {
            base.Initialize(data);
            claimButton.onClick.AddListener(OnClaimButtonClick);
        }

        public void Show()
        {
            canvasGroup.DOFade(1, 0.25f).SetEase(Ease.Flash);
        }

        public void Hide()
        {
            canvasGroup.DOFade(0, 0.15f).SetEase(Ease.Flash);
        }
        
        private void OnClaimButtonClick()
        {
            base.FireCallback();
        }
    }
}