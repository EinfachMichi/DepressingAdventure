using System;
using Main;
using UnityEngine;

public class QuestNarrator : MonoBehaviour
{
    public bool Quest1;

    private AudioClip clip;
    
    public void Start()
    {
        Invoke("LateStart", 0.5f);
        Quest_01ButtonInput.Instance.OnRoundResults += OnRoundResults;
    }

    private void OnRoundResults(int round, bool playerwon)
    {
        if (round == 3 && !playerwon)
        {
            PlayTrack(20);
        }
        else if (round == 4 && !playerwon)
        {
            PlayTrack(22);
        }
    }

    private void LateStart()
    {
        PlayTrack(17);
        Invoke("StartSteve", clip.length);
    }

    private void StartSteve()
    {
        PlayTrack(19);
    }

    private void PlayTrack(int id)
    {
        Narrator.Instance.MainPlay(id);
        clip = Narrator.Instance.CurrentClip;
        if (clip == null) return;
        Quest_01ButtonInput.Instance.Pause();
        Invoke("UnPause", Narrator.Instance.CurrentClip.length);
    }
    
    private void UnPause()
    {
        Quest_01ButtonInput.Instance.UnPause();
    }
}