using System.Collections.Generic;
using Superplay.UI.Manager;
using Superplay.UI.Widget;
using UnityEngine;

namespace Superplay.UI.Config
{
    [CreateAssetMenu(fileName = "UIManagerConfig", menuName = "Superplay/UI/UIManagerConfig", order = 0)]
    public class UIManagerConfig : ScriptableObject
    {
        public List<UIManagerConfigData> Widgets => widgetsList;
        
        [SerializeField]
        private List<UIManagerConfigData> widgetsList = new List<UIManagerConfigData>();

        public IUIWidget GetWidgetByType(UIWidgetNames widgetName)
        {
            return widgetsList.Find(x => x.type == widgetName).uiWidget;
        }
    }
}