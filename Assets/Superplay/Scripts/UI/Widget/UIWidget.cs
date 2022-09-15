using System;
using DG.Tweening;
using Superplay.UI.Data;
using UnityEngine;

namespace Superplay.UI.Widget
{
    public class UIWidget : MonoBehaviour, IUIWidget
    {
        public event Action WidgetCallback;
        
        [SerializeField]
        protected CanvasGroup canvasGroup;

        private IWidgetData _data;

        public void Initialize(IWidgetData data)
        {
            _data = data;
        }

        public GameObject GameObject => gameObject;

        public void Show()
        {
            canvasGroup.DOFade(1, 0.25f).SetEase(Ease.Flash);
        }

        public void Hide()
        {
            canvasGroup.DOFade(0, 0.15f).SetEase(Ease.Flash);
        }

        public void ShowInstant()
        {
            canvasGroup.DOFade(1, 0);
        }

        public void HideInstant()
        {
            canvasGroup.DOFade(0, 0);
        }

        protected virtual void FireCallback()
        {
            WidgetCallback?.Invoke();
        }
    }
}