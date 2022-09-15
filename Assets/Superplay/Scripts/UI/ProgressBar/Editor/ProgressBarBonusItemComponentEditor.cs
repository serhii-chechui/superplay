using UnityEditor;
using UnityEngine;

namespace Superplay.UI.ProgressBar.Editor
{
    [CustomEditor(typeof(ProgressBarBonusItemComponent))]
    public class ProgressBarBonusItemComponentEditor : UnityEditor.Editor
    {
        private int _bonusItemsCount;
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var progressBarBonusItemComponent = (ProgressBarBonusItemComponent) target;

            _bonusItemsCount = EditorGUILayout.IntSlider("Bonus Items Count", _bonusItemsCount, 1, 999);

            if (GUILayout.Button("Update Bonus Item"))
            {
                progressBarBonusItemComponent.UpdateBonusItem(BonusItemTypes.RainbowPack, _bonusItemsCount);
            }
            
            if (GUILayout.Button("Show Bonus Item"))
            {
                progressBarBonusItemComponent.Show();
            }
            
            if (GUILayout.Button("Hide Bonus Item"))
            {
                progressBarBonusItemComponent.Hide();
            }
        }
    }
}