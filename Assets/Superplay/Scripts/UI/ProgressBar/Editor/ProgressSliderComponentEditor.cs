using UnityEditor;
using UnityEditor.UI;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Superplay.UI.ProgressBar.Editor
{
    [CustomEditor(typeof(ProgressSliderComponent))]
    public class ProgressSliderComponentEditor : SliderEditor
    {
        private float _progress;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        
            var progressSliderComponent = (ProgressSliderComponent)target;

            _progress = EditorGUILayout.Slider("Progress",_progress, 0, 1);

            progressSliderComponent.SetProgressInstant(_progress);
        
            EditorGUILayout.Space();

            if (GUILayout.Button("Set 0"))
            {
                _progress = 0f;
                progressSliderComponent.SetProgress(_progress);
            }
        
            if (GUILayout.Button("Set Random"))
            {
                _progress = Random.Range(0.01f, 0.99f);
                progressSliderComponent.SetProgress(_progress);
            }
        
            if (GUILayout.Button("Set 1"))
            {
                _progress = 1f;
                progressSliderComponent.SetProgress(_progress);
            }
        }
    }
}
