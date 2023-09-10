public class GameController
{
    private PlayerController _playerController;
    private UIService _uiService;
    private HudWindowController _hudWindowController;
    private ScoreCounter _scoreCounter;
    private SoundController _soundController;

    public GameController(
        PlayerController playerController,
        UIService uIService,
        HudWindowController hudWindowController,
        ScoreCounter scoreCounter,
        SoundController soundController,
        UIService uiService)
    {
        _playerController = playerController;
        _uiService = uIService;
        _hudWindowController = hudWindowController;
        _scoreCounter = scoreCounter;
        _soundController = soundController;
        _uiService = uiService;
    }
}