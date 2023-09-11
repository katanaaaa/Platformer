using UI.UIService;

public class GameController
{
    private PlayerController _playerController;
    private UIService _uiService;
    private SoundController _soundController;

    public GameController(
        PlayerController playerController,
        SoundController soundController,
        UIService uiService)
    {
        _playerController = playerController;
        _uiService = uiService;
        _soundController = soundController;
    }
}