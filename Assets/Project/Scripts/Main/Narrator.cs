using System;
using UnityEngine;

namespace Main
{
    public class Narrator : Singleton<Narrator>
    {
        public AudioSource Source;
        public NarratorClip[] Clips;
        
        public void Play(int ID)
        {
            if (GameManager.Instance.Data.Played(ID)) return;
            
            GameStateManager.Instance.ChangeAudioState(AudioState.InTalk);
            Source.Stop();
            Source.clip = GetClipByID(ID);
            Source.Play();
            Invoke("ChangeState", Source.clip.length);
            GameManager.Instance.Data.SetPlayed(ID);
        }

        private void ChangeState()
        {
            GameStateManager.Instance.ChangeAudioState(AudioState.None);
        }
        
        private void Start()
        {
            if (!GameManager.Instance.Data.NarratorLoaded)
            {
                GameManager.Instance.Data.NarratorInfos = new NarratorInfo[Clips.Length];
                for (int i = 0; i < Clips.Length; i++)
                {
                    NarratorInfo info = new NarratorInfo();
                    info.ID = Clips[i].ID;
                    info.Played = false;
                    GameManager.Instance.Data.NarratorInfos[i] = info;
                }
                GameManager.Instance.Data.NarratorLoaded = true;
                GameManager.Instance.Save();
            }
        }

        private AudioClip GetClipByID(int ID)
        {
            foreach (NarratorClip clip in Clips)
            {
                if (clip.ID == ID)
                {
                    return clip.Clip;
                }
            }
            return null;
        }
    }

    [Serializable]
    public class NarratorClip
    {
        public int ID;
        public AudioClip Clip;
    }

    public enum AudioState
    {
        None,
        InTalk
    }
}