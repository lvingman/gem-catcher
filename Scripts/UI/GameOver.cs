using Godot;
using System;
using GemCatcher.Scripts;
using GemCatcher.Scripts.Globals;
using GemCatcher.Scripts.Globals.Enums;

public partial class GameOver : Control
{
    [Export] private Label _scoreLabel;
    [Export] private Button _tryAgainButton;

    public override void _Ready()
    {
        ConnectSignals();
        _scoreLabel ??= GetNode<Label>("PanelContainer/VBoxContainer/Score");
        _tryAgainButton ??= GetNode<Button>("PanelContainer/VBoxContainer/TryAgain");
    }

    private void UpdateScore(int score)
    {
        _scoreLabel.Text = $"Score: {score}";
    }

    private void ConnectSignals()
    {
        _tryAgainButton.Pressed += OnTryAgainButtonPressed;
        SignalManager.Instance.ConnectSignalToFunction(OnGameOver, signals.ON_GAME_OVER);
    }

    private void OnGameOver()
    {
        UpdateScore(Score.Instance.GetScore());
        SetVisible(!Visible);
    }
    private void OnTryAgainButtonPressed()
    {
        GetTree().ReloadCurrentScene();
    }
}
