namespace GemCatcher.Scripts.Globals;

using Godot;

public partial class GlobalValues : Node2D
{
    private Rect2 _viewportRect;
    public static GlobalValues Instance { get; private set; }
    public override void _Ready()
    {
        Instance = this;
        _viewportRect = GetViewportRect();
    }

    public Vector2 GetViewportEnd()
    {
        return _viewportRect.End;
    }

    public Vector2 GetViewportStart()
    {
        return _viewportRect.Position;
    }
    
}