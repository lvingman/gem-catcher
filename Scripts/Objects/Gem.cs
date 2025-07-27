using Godot;
using System;

public partial class Gem : Area2D
{
	[Export] private float _initialSpeed = 30.0f;
	public override void _Ready()
	{
		_initialSpeed *= 10;
	}

	public override void _Process(double delta)
	{
		Fall(delta);
	}

	private void Fall(double delta)
	{
		Position += new Vector2(0, _initialSpeed * (float)delta);
	}
}
