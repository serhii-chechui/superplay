using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Superplay.UI.ProgressBar
{
    public class ProgressTimerComponent : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _timerText;

        private TimeSpan _timeSpan;

        private Coroutine _timerCoroutine;
        
        #if UNITY_EDITOR
        private new void OnValidate()
        {
            if (_timerText == null)
            {
                _timerText = GetComponent<TextMeshProUGUI>();
            }
        }
    
        #endif

        public void Initialize()
        {
            
        }
        
        public void SetTimerInitialValue(TimeSpan timeSpan)
        {
            _timeSpan = timeSpan;
            UpdateTimerCounter();
        }

        public void StartTimer()
        {
            if (_timerCoroutine != null)
            {
                StopCoroutine(_timerCoroutine);
            }
            
            _timerCoroutine = StartCoroutine(StartTimerCo());
        }
        
        public void StopTimer()
        {
            if (_timerCoroutine != null)
            {
                StopCoroutine(_timerCoroutine);
            }

            _timeSpan = TimeSpan.Zero;
            UpdateTimerCounter();
        }

        private IEnumerator StartTimerCo()
        {
            while (_timeSpan.Seconds > 0)
            {
                yield return new WaitForSeconds(1f);
                _timeSpan = _timeSpan.Add(new TimeSpan(0, 0, -1));
                UpdateTimerCounter();
            }

            StopTimer();
        }

        private void UpdateTimerCounter()
        {
            _timerText.text = $"{_timeSpan.Hours:00}:{_timeSpan.Minutes:00}:{_timeSpan.Seconds:00}";
        }
    }
}