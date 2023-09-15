using UI.UIService;

namespace UI.UIWindows
{
    public class UIMainMenuController
    {
        private readonly IUIService _uiService;
        private readonly UIMainMenuWindow _mainMenuWindow;
        private readonly GameController _gameController;

        public UIMainMenuController(IUIService uiService, GameController gameController)
        {
            _uiService = uiService;
            _gameController = gameController;
            _mainMenuWindow = uiService.Get<UIMainMenuWindow>();
            
            _mainMenuWindow.OnShowEvent += ShowWindow;
            _mainMenuWindow.OnHideEvent += HideWindow;
        }

        private void ShowWindow()
        {
            _mainMenuWindow.OnStartButtonClickEvent += ShowGameWindow;
            _mainMenuWindow.OnStartButtonClickEvent += _gameController.StartGame;
        }
        private void HideWindow()
        {
            _mainMenuWindow.OnStartButtonClickEvent -= ShowGameWindow;
            _mainMenuWindow.OnStartButtonClickEvent -= _gameController.StartGame;
        }
        private void ShowGameWindow()
        {
            _uiService.Hide<UIMainMenuWindow>();
            _uiService.Show<UIGameWindow>();
        }
    }
}