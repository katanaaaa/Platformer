using Player;
using Sounds;
using UI.UIService;

public class GameController
{
    private SoundController _soundController;
    private UIService _uiService;
    private PlayerController _playerController;

    public GameController(
        SoundController soundController,
        UIService uiService,
        PlayerController playerController)
    {
        _uiService = uiService;
        _soundController = soundController;
        _playerController = playerController;
    }

    private void ScoreInit()
    {
        
    }

    public void InitGame()
    {
        
    }

    public void StartGame()
    {
        
    }

    public void StopGame()
    {
        
    }
}