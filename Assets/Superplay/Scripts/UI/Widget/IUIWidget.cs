using System;
using UnityEngine;

namespace Superplay.UI.Widget
{
    public interface IUIWidget
    {
        event Action WidgetCallback;
        GameObject GameObject { get; }
        void Show();
        void Hide();
        
        void ShowInstant();
        
        void HideInstant();
    }
}