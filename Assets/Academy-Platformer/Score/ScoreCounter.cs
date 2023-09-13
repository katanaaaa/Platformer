using System;
using FallObject;
using Sounds;

public class ScoreCounter
{
    public event Action<int> ScoreChangeNotify;
    public int Score => _score;

    private SoundController _soundController;

    private int _score = 0;

    public ScoreCounter(SoundController soundController)
    {
        _soundController = soundController;
    }
}