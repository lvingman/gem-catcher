using Godot;
using System;
using GemCatcher.Scripts.Globals;

public partial class GameOver : Control
{
    private Label _scoreLabel;
    private Button _tryAgainButton;

    public override void _Ready()
    {
        _scoreLabel = GetNode<Label>("ScoreLabel");
        _tryAgainButton = GetNode<Button>("TryAgainButton");
    }

    private void UpdateScore(int score)
    {
        _scoreLabel.Text = $"Score: {Score.Instance.GetScore()}";
    }

    private void ConnectSignals()
    {
        _tryAgainButton.Pressed += OnTryAgainButtonPressed;
    }

    private void OnTryAgainButtonPressed()
    {
        GetTree().ReloadCurrentScene();
    }
}
