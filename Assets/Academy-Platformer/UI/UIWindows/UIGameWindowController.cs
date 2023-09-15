using UI.HUD;
using UI.UIService;

namespace UI.UIWindows
{
    public class UIGameWindowController
    {
        private readonly IUIService _uiService;
        
        public UIGameWindowController(IUIService uiService)
        {
            _uiService = uiService;
        }

        public void ShowEndMenuWindow()
        {
            _uiService.Hide<UIGameWindow>();
            _uiService.Hide<HUDWindow>();
            _uiService.Show<UIEndGameWindow>();
        }
    }
}