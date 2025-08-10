using System;
using GemCatcher.Scripts.Globals.Enums;
using Godot;

namespace GemCatcher.Scripts;

public partial class SignalManager : Node
{
    [Signal] public delegate void OnScoreEventHandler();
    public static SignalManager Instance { get; private set; }
    public override void _Ready()
    {
        Instance = this;
    }

    public void ConnectSignalToFunction(Action functionToConnect, string functionName)
    {
        var callableFunction = Callable.From(functionToConnect);
        switch (functionName)
        {
            case signals.ON_SCORE:
                Connect(SignalName.OnScore, callableFunction);
                break;
        }
    }
}