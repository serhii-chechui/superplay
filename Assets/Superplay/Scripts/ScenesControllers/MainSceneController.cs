using System;
using Superplay.UI.Manager;
using Superplay.UI.Popup;
using Superplay.UI.ProgressBar;
using Superplay.VFX;
using UnityEngine;

namespace Superplay.Scripts.UI.ScenesController
{
    public class MainSceneController : MonoBehaviour
    {
        [SerializeField]
        private UIManager _uiManager;
        
        [SerializeField]
        private VFXManager _vfxManager;

        private void Awake()
        {
            _uiManager.Initialize();

            var progressBarWidget = (ProgressBarWidget)_uiManager.GetWidgetByName(UIWidgetNames.ProgressBar);
            progressBarWidget.Initialize(new ProgressBarWidgetData { progress = 0.35f });
            progressBarWidget.WidgetCallback += OnProgressbarWidgetCallback;
        }

        private void Start()
        {
            _uiManager.ShowWidget(UIWidgetNames.ProgressBar);
        }

        private void OnProgressbarWidgetCallback()
        {
            _uiManager.HideWidget(UIWidgetNames.ProgressBar);
            
            var popupWidget = (PopupWidget)_uiManager.GetWidgetByName(UIWidgetNames.Popup);
            popupWidget.WidgetCallback += OnPopupWidgetCallback;
            popupWidget.Initialize(new PopupWidgetData());
            _uiManager.ShowWidget(UIWidgetNames.Popup);
        }

        private void OnPopupWidgetCallback()
        {
            _uiManager.HideWidget(UIWidgetNames.Popup);
            _vfxManager.SpawnVFX(VFXTypes.REWARD, null, true);
        }
    }
}