using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Superplay.UI.ProgressBar
{
    public class ProgressSliderComponent : Slider
    {
        public event Action ProgressCompletedEvent;
    
        [SerializeField]
        private TextMeshProUGUI _progessText;

        #if UNITY_EDITOR
        private new void OnValidate()
        {
            base.OnValidate();
        
            if (_progessText == null)
            {
                _progessText = GetComponentInChildren<TextMeshProUGUI>();
            }
        }
    
        #endif

        public void Initialize()
        {
            if (_progessText == null)
            {
                _progessText = GetComponentInChildren<TextMeshProUGUI>();
            }

            // onValueChanged.AddListener(OnSliderValueChanged);
        }

        public void Dismiss()
        {
            // onValueChanged.RemoveListener(OnSliderValueChanged);
        }

        public void SetProgress(float value)
        {
            DOTween.To(() => base.value, x => base.value = x, value, 1)
                .OnStart(() =>
                {
                    _progessText.transform.DOPunchScale(Vector3.one * 0.15f, 0.35f, 3, 0.5f)
                        .OnComplete(() =>
                        {
                            _progessText.transform.DOScale(1f, 0f);
                        });
                })
                .OnUpdate(() =>
                {
                    var integerValue = Mathf.Ceil(base.value * 100f);
                    _progessText.text = $"{integerValue} / 100";
                }).OnComplete(() =>
                {
                    if (value >= 1f)
                    {
                        ProgressCompletedEvent?.Invoke();
                    }
                });
        }
    
        public void SetProgressInstant(float value)
        {
            base.value = value;
        
            var integerValue = Mathf.Ceil(value * 100f);
            _progessText.text = $"{integerValue} / 100";
        }

        private void OnSliderValueChanged(float value)
        {
            if (value >= 1f)
            {
                ProgressCompletedEvent?.Invoke();
            }
        }
    }
}
