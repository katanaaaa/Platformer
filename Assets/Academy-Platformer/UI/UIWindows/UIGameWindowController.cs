using UI.HUD;
using UI.UIService;

namespace UI.UIWindows
{
    public class UIGameWindowController
    {
        private readonly IUIService _uiService;
        
        private UIGameWindow _GameWindow;

        public UIGameWindowController(IUIService uiService)
        {
            _uiService = uiService;
            _GameWindow = uiService.Get<UIGameWindow>();
        }

        public void ShowEndMenuWindow()
        {
            _uiService.Hide<UIGameWindow>();
            _uiService.Hide<HUDWindow>();
            _uiService.Show<UIEndGameWindow>();
        }
    }
}