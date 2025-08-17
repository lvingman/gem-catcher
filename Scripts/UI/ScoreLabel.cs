using Godot;
using System;
using GemCatcher.Scripts;
using GemCatcher.Scripts.Globals;
using GemCatcher.Scripts.Globals.Enums;

public partial class ScoreLabel : Label
{
    public override void _Ready()
    {
        ConnectSignals();
    }

    private void ConnectSignals()
    {
        SignalManager.Instance.ConnectSignalToFunction(UpdateScore, signals.ON_SCORE);
    }

    private void UpdateScore()
    {
        Text = $"SCORE:  {Score.Instance.GetScore()}";
    }
}

    