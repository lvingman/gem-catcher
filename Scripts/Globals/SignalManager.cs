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
        ConnectSignalToFunction(connectingCode, signals.ON_GAME_OVER);
    }
    public void ConnectToScoreSignal(Action connectingCode)
    {
        ConnectSignalToFunction(connectingCode, signals.ON_SCORE);
    }
    public void ConnectToSceneReloadSignal(Action connectingCode)
    {
        ConnectSignalToFunction(connectingCode, signals.ON_SCENE_RELOAD);
    }

    private void ConnectSignalToFunction(Action functionToConnect, string signalName)
    {
        var callableFunction = Callable.From(functionToConnect);
        switch (signalName)
        {
            case signals.ON_SCORE:
                Connect(SignalName.OnScore, callableFunction);
                break;
            case signals.ON_GAME_OVER:
                Connect(SignalName.OnGameOver, callableFunction);
                break;
            case signals.ON_SCENE_RELOAD:
                Connect(SignalName.OnSceneReload, callableFunction);
                break;
            default:
                GD.Print("Signal not set up at ConnectSignalToFunction");
                break;
        }
    }
}