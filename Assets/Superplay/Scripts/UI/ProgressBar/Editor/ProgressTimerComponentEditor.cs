using System;
using UnityEditor;
using UnityEngine;

namespace Superplay.UI.ProgressBar.Editor
{
    [CustomEditor(typeof(ProgressTimerComponent))]
    public class ProgressTimerComponentEditor : UnityEditor.Editor
    {
        private int _hours;
        private int _minutes;
        private int _seconds;

        private long _ticks;
        
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var progressTimerComponent = (ProgressTimerComponent)target;
            
            EditorGUILayout.Space();

            _hours = EditorGUILayout.IntSlider("Hours", _hours, 0, 24);
            _minutes = EditorGUILayout.IntSlider("Minutes", _minutes, 0, 59);
            _seconds = EditorGUILayout.IntSlider("Seconds", _seconds, 0, 59);
            
            EditorGUILayout.Space();

            if (GUILayout.Button("Set Timer Value"))
            {
                var timeSpan = new TimeSpan(_hours, _minutes, _seconds);
                progressTimerComponent.SetTimerInitialValue(timeSpan);
            }

            if (GUILayout.Button("Start Timer"))
            {
                progressTimerComponent.StartTimer();
            }
            
            if (GUILayout.Button("Stop Timer"))
            {
                progressTimerComponent.StopTimer();
            }
        }
    }
}