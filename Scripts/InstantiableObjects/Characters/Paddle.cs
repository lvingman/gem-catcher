using Godot;
using System;
using GemCatcher.Scripts;
using GemCatcher.Scripts.Globals;
using GemCatcher.Scripts.Globals.Enums;
using InputMap = GemCatcher.Scripts.Globals.InputMap;

public partial class Paddle : CharacterBody2D
{
    [Export] private float _speed = 50.0f;
    [Export] private float _margin = 50.0f;
    public override void _Ready()
    {
        _speed *= 10;
        ConnectSignals();
    }

    public override void _Process(double delta)
    {
        MoveCharacter(delta);
    }
    private void MoveCharacter(double delta)
    {
        Vector2 movement = new Vector2(Convert.ToInt32(ShouldMoveRight()) - Convert.ToInt32(ShouldMoveLeft()), 0);
        Position += movement * _speed * (float)delta;
    }

    private bool ShouldMoveRight()
    {
        return Input.IsActionPressed(InputMap.MOVE_RIGHT) && !(IsOnRightBounds());
    }

    private bool ShouldMoveLeft()
    {
        return Input.IsActionPressed(InputMap.MOVE_LEFT) && !(IsOnLeftBounds());
    }

    private bool IsOnRightBounds()
    {
        return Position.X >= GlobalValues.Instance.GetViewportEnd().X - _margin;
    }

    private bool IsOnLeftBounds()
    {
        return Position.X <= GlobalValues.Instance.GetViewportStart().X + _margin;
    }

    private void OnGameOver()
    {
        _speed = 0;
    }
    private void ConnectSignals()
    {
        SignalManager.Instance.ConnectToGameOverSignal(OnGameOver);
    }
}