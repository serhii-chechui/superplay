using System.Collections.Generic;
using Superplay.UI.Config;
using Superplay.UI.Popup;
using Superplay.UI.ProgressBar;
using Superplay.UI.Widget;
using UnityEngine;

namespace Superplay.UI.Manager
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        private UIManagerConfig uiManagerConfig;
        
        public Dictionary<UIWidgetNames, IUIWidget> Widgets => _widgets;
        private Dictionary<UIWidgetNames, IUIWidget> _widgets = new Dictionary<UIWidgetNames, IUIWidget>();

        public void Initialize()
        {
            foreach (var widget in uiManagerConfig.Widgets)
            {
                var widgetInstance = Instantiate(widget.uiWidget, transform);
                _widgets.Add(widget.type, widgetInstance);
            }
            
            HideAll();
        }

        public void ShowWidget(UIWidgetNames widgetName)
        {
            if(!_widgets.ContainsKey(widgetName)) return;
            
            _widgets[widgetName].Show();
        }
        
        public void HideWidget(UIWidgetNames widgetName)
        {
            if(!_widgets.ContainsKey(widgetName)) return;
            
            _widgets[widgetName].Hide();
        }

        public void HideAll()
        {
            foreach (var widget in _widgets)
            {
                widget.Value.HideInstant();
            }
        }

        public IUIWidget GetWidgetByName(UIWidgetNames widgetName)
        {
            return _widgets[widgetName];
        }
    }
}