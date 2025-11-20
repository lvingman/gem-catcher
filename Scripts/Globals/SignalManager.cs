using System;
using System.Linq.Expressions;
using GemCatcher.Scripts.Globals.Enums;
using Godot;

namespace GemCatcher.Scripts;

public partial class SignalManager : Node
{
    [Signal] public delegate void OnGameOverEventHandler();
    [Signal] public delegate void OnScoreEventHandler();
    [Signal] public delegate void OnSceneReloadEventHandler();
    public static SignalManager Instance { get; private set; }
    public override void _Ready()
    {
        Instance = this;
    }

    public void ConnectToGameOverSignal(Action connectingCode)
    {
        try
        {
            Callable function = Callable.From(connectingCode);
            Connect(SignalName.OnGameOver, function);
        }
        catch (Exception e)
        {
            GD.Print("Couldn't associate code to Game Over signal");
        }
    }
    public void ConnectToScoreSignal(Action connectingCode)
    {
        try
        {
            Callable function = Callable.From(connectingCode);
            Connect(SignalName.OnScore, function);
        }
        catch (Exception e)
        {
            GD.Print("Couldn't associate code to Score signal");
        }
    }
    public void ConnectToSceneReloadSignal(Action connectingCode)
    {
        try
        {
            Callable function = Callable.From(connectingCode);
            Connect(SignalName.OnSceneReload, function);
        }
        catch (Exception e)
        {
            GD.Print("Couldn't associate code to Scene Reload signal");
        }
    }
}