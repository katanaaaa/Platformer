using FallObject;
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
    private readonly InputController _inputController;
    private readonly PlayerController _playerController;
    private readonly ScoreCounter _scoreCounter;
    private readonly FallObjectSpawner _fallObjectSpawner;

    public GameController(
        SoundController soundController,
        IUIService uiService,
        UIGameWindowController gameWindowController,
        HUDWindowController hudWindowController,
        InputController inputController,
        PlayerController playerController,
        ScoreCounter scoreCounter,
        FallObjectSpawner fallObjectSpawner)
    {
        _soundController = soundController;
        _uiService = uiService;
        _gameWindowController = gameWindowController;
        _inputController = inputController;
        _playerController = playerController;
        _scoreCounter = scoreCounter;
        _fallObjectSpawner = fallObjectSpawner;

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
        _inputController.EnableTick();
        _playerController.Spawn();
        _fallObjectSpawner.Start();
    }

    private void StopGame()
    {
        _inputController.DisableTick();
        _playerController.DestroyView(() => _gameWindowController.ShowEndMenuWindow());
        _fallObjectSpawner.Stop();
    }
}