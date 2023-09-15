using System;
using FallObject;
using Sounds;

public class ScoreCounter
{
    public event Action<int> ScoreChangeNotify;
    public int Score => _score;

    private SoundController _soundController;

    private int _score;

    public ScoreCounter(SoundController soundController)
    {
        _soundController = soundController;
    }

    public void PlayerCatchFallObjectEventHandler(FallObjectController fallObjectController)
    {
        _soundController.Play(SoundName.Buff1);
        _score += fallObjectController.PointsPerObject;
        ScoreChangeNotify?.Invoke(_score);
    }
}