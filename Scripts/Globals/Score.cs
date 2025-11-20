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
        SignalManager.Instance.ConnectToScoreSignal(AddScore);
        SignalManager.Instance.ConnectToSceneReloadSignal(OnSceneReload);
    }

    private void OnSceneReload()
    {
        _score = 0;
    }

}