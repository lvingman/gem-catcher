using GemCatcher.Scripts;
using Godot;

public partial class Spawner : Node2D
{
    [Export] private PackedScene _toSpawn;
    private AnimationPlayer _animationPlayer;

    public override void _Ready()
    {
        ConnectSignals();
        _animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
    }

    private void SpawnObject()
    {
        Gem spawn = _toSpawn.Instantiate<Gem>();
        spawn.GlobalPosition = GlobalPosition;
        GetTree().Root.CallDeferred("add_child", spawn);
        _animationPlayer.SetSpeedScale(_animationPlayer.GetSpeedScale()+0.1f);
    }
    
    private void ConnectSignals()
    {
        SignalManager.Instance.ConnectToScoreSignal(SpawnObject);
    }
}
