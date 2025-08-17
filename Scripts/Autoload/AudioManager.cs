using Godot;
using System;
using System.Collections.Generic;
using GemCatcher.Scripts;
using GemCatcher.Scripts.Globals.Enums;

public partial class AudioManager : Node
{
    [Export] private Node Music;
    [Export] private Node SFX;
    private AudioStreamPlayer MusicPlayer;
    private List<AudioStreamPlayer> SFXs = new List<AudioStreamPlayer>();
    public override void _Ready()
    {
        LoadAudio();
        ConnectSignals();
        MusicPlayer.Play();
    }

    private void LoadAudio()
    {
        foreach (var child in Music.GetChildren())
        {
            if (child is AudioStreamPlayer music)
            {
                music.Bus = buses.MUSIC;
                MusicPlayer = music;
            }
        }

        foreach (var child in SFX.GetChildren())
        {
            if (child is AudioStreamPlayer sfx)
            {
                sfx.Bus = buses.SFX;
                SFXs.Add(sfx);
            }
        }
    }
    private void ConnectSignals()
    {
        SignalManager.Instance.ConnectSignalToFunction(OnGameOver, signals.ON_GAME_OVER);
        SignalManager.Instance.ConnectSignalToFunction(OnScore, signals.ON_SCORE);
        SignalManager.Instance.ConnectSignalToFunction(OnSceneReloading, signals.ON_SCENE_RELOAD);
    }

    private void OnSceneReloading()
    {
        MusicPlayer.Play();
    }

    private void OnGameOver()
    {
        MusicPlayer.Stop();
        PlaySFX(sfxs.GAME_OVER);
    }

    private void OnScore()
    {
        PlaySFX(sfxs.GEM_CAUGHT);
    }
    
    public void PlaySFX(string name)
    {
        AudioStreamPlayer player = null;
        try
        {
            player = SFXs.Find(p => p.Name == name);
            player.Play();
        }
        catch (Exception e)
        {
            GD.PrintErr(e);
        }
    }
    
    
}
