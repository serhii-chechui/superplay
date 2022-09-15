using Superplay.UI.Manager;
using UnityEditor;
using UnityEngine;

namespace Superplay.UI.Editor
{
    [CustomEditor(typeof(UIManager))]
    public class UIManagerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var uiManager = (UIManager)target;

            if (uiManager.Widgets != null)
            {
                if (uiManager.Widgets.Count == 0)
                {
                    if (GUILayout.Button("Initialize"))
                    {
                        uiManager.Initialize();
                    }
                }
                else
                {
                    EditorGUILayout.BeginVertical(EditorStyles.helpBox);

                    foreach (var widget in uiManager.Widgets)
                    {
                        EditorGUILayout.BeginHorizontal(EditorStyles.helpBox);
                    
                        EditorGUILayout.LabelField($"{widget.Value.GameObject.name}");

                        if (GUILayout.Button("Show"))
                        {
                            widget.Value.Show();
                        }
                    
                        if (GUILayout.Button("Hide"))
                        {
                            widget.Value.Hide();
                        }
                    
                        EditorGUILayout.EndHorizontal();
                    }
                
                    EditorGUILayout.EndVertical();
                }
            }
        }
    }
}