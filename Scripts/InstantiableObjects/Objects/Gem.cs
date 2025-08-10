using Godot;
using System;
using GemCatcher.Scripts;
using GemCatcher.Scripts.Globals;

public partial class Gem : Area2D
{
	[Export] private float _initialSpeed = 30.0f;
	public override void _Ready()
	{
		_initialSpeed *= (10 + GlobalValues.Instance.GetIncreasingGemSpeed());
		ConnectSignals();
	}

	public override void _Process(double delta)
	{
		Fall(delta);
	}

	private void Fall(double delta)
	{
		Position += new Vector2(0, _initialSpeed * (float)delta);
	}

	private void OnBodyEntered(Node2D body)
	{
		if (body is Paddle)
		{
			GD.Print("Score before signal: " + Score.Instance.GetScore());
			SignalManager.Instance.EmitSignal(SignalManager.SignalName.OnScore);
			QueueFree();
		}
	}

	private void ConnectSignals()
	{
		BodyEntered += OnBodyEntered;
	}
}
