using Player;
using Sounds;
using UI.HUD;
using UI.UIService;
using UI.UIWindows;

public class GameController
{
    private SoundController _soundController;
    private IUIService _uiService;
    private readonly UIGameWindowController _gameWindowController;
    private readonly PlayerController _playerController;
    private readonly ScoreCounter _scoreCounter;

    public GameController(
        SoundController soundController,
        IUIService uiService,
        UIGameWindowController gameWindowController,
        HUDWindowController hudWindowController,
        PlayerController playerController,
        ScoreCounter scoreCounter)
    {
        _soundController = soundController;
        _uiService = uiService;
        _gameWindowController = gameWindowController;
        _playerController = playerController;
        _scoreCounter = scoreCounter;

        _scoreCounter.ScoreChangeNotify += hudWindowController.ChangeScore;
        _playerController.PlayerHp.OnZeroHealth += StopGame;
        
        InitGame();
    }

    private void InitGame()
    {
        _uiService.Show<UIMainMenuWindow>();
        _soundController.Play(SoundName.BackStart, loop: true);
    }

    public void StartGame()
    {
        _soundController.Stop();
        _soundController.Play(SoundName.BackMain, loop: true);

        _playerController.Spawn();
    }

    private void StopGame()
    {
        _playerController.DestroyView(() => _gameWindowController.ShowEndMenuWindow());
    }
}