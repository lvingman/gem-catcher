using Godot;
using System;
using GemCatcher.Scripts.Globals;
using InputMap = GemCatcher.Scripts.Globals.InputMap;

public partial class Paddle : CharacterBody2D
{
    [Export] private float _speed = 50.0f;
    [Export] private float _margin = 50.0f;
    public override void _Ready()
    {
        _speed *= 10;
    }

    public override void _Process(double delta)
    {
        MoveCharacter(delta);
    }
    private void MoveCharacter(double delta)
    {
        if (IsMovingLeft())
        {
            Position -= new Vector2(_speed * (float)delta, 0);
        }
        else if (IsMovingRight())
        {
            Position += new Vector2(_speed * (float)delta, 0);
        }
    }

    private bool IsMovingRight()
    {
        return Input.IsActionPressed(InputMap.MOVE_RIGHT) && !(IsOnRightBounds());
    }

    private bool IsMovingLeft()
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
    
}