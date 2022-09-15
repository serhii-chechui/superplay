using Superplay.UI.Widget;
using UnityEngine;
using UnityEngine.UI;

namespace Superplay.UI.ProgressBar
{
    public class ProgressBarWidget : UIWidget
    {
        [Header("Progress Bar")]
        [SerializeField]
        private ProgressSliderComponent _progressSlider;

        [Header("Timer")]
        [SerializeField]
        private ProgressTimerComponent _timerComponent;

        [Header("Debug")]
        [SerializeField]
        private Button zeroButton;
    
        [SerializeField]
        private Button completeButton;

        public void Initialize(ProgressBarWidgetData data)
        {
            base.Initialize(data);
        
            if (_progressSlider == null)
            {
                _progressSlider = GetComponentInChildren<ProgressSliderComponent>();
            }
        
            _progressSlider.Initialize();
            _progressSlider.ProgressCompletedEvent += ProgressSliderOnProgressCompletedEvent;
            _progressSlider.SetProgressInstant(data.progress);
        
            if (_timerComponent == null)
            {
                _timerComponent = GetComponentInChildren<ProgressTimerComponent>();
            }
        
            _timerComponent.Initialize();
        
            zeroButton.onClick.AddListener(delegate
            {
                _progressSlider.SetProgress(0);
            });
        
            completeButton.onClick.AddListener(delegate
            {
                _progressSlider.SetProgress(1);
            });
        }

        public void Dismiss()
        {
            _progressSlider.ProgressCompletedEvent -= ProgressSliderOnProgressCompletedEvent;
            _progressSlider.Dismiss();
        
            zeroButton.onClick.RemoveAllListeners();
            completeButton.onClick.RemoveAllListeners();
        }
    
        private void ProgressSliderOnProgressCompletedEvent()
        {
            FireCallback();
        }
    }
}