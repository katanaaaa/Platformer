using UI.UIService;
using UI.UIWindows;

public class GameController
{
    private IUIService _uiService;

    public GameController(IUIService uiService)
    {
        _uiService = uiService;
        
        InitGame();
    }

    private void InitGame()
    {
        _uiService.Show<UIMainMenuWindow>();
    }

    public void StartGame()
    {
        
    }

    public void StopGame()
    {
        
    }
}