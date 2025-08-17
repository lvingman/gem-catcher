using GemCatcher.Scripts.Globals.Enums;
using Godot;

namespace GemCatcher.Scripts.Globals;

public partial class Score : Node
{
    private int _score;
    public static Score Instance { get; private set; }
    public override void _Ready()
    {
        Instance = this;
        _score = 0;
        ConnectSignals();
    }

    private void AddScore()
    {
        _score += 100;
        GD.Print("Score after signal: " + _score);
    }
    
    
    
    public int GetScore() => _score;

    private void ConnectSignals()
    {
        SignalManager.Instance.ConnectSignalToFunction(AddScore, signals.ON_SCORE);
        SignalManager.Instance.ConnectSignalToFunction(OnSceneReload, signals.ON_SCENE_RELOAD);
    }

    private void OnSceneReload()
    {
        _score = 0;
    }

}