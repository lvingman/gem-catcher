using GemCatcher.Scripts.Globals.Enums;

namespace GemCatcher.Scripts.Globals;

using Godot;

public partial class GlobalValues : Node2D
{
    private float _increasingGemSpeed;
    private Rect2 _viewportRect;
    public static GlobalValues Instance { get; private set; }
    public override void _Ready()
    {
        ConnectSignals();
        Instance = this;
        _viewportRect = GetViewportRect();
        _increasingGemSpeed = 0;
    }

    public Vector2 GetViewportEnd()
    {
        return _viewportRect.End;
    }

    public Vector2 GetViewportStart()
    {
        return _viewportRect.Position;
    }
 
    private void ConnectSignals()
    {
        SignalManager.Instance.ConnectSignalToFunction(IncreaseGemSpeed, signals.ON_SCORE);
    }

    private void IncreaseGemSpeed()
    {
        _increasingGemSpeed += 0.1f;
    }

    public float GetIncreasingGemSpeed()
    {
        return _increasingGemSpeed;
    }
}