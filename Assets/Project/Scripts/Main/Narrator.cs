using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Main
{
    public class Narrator : Singleton<Narrator>
    {
        public AudioSource MainSource;
        public AudioSource SideSource;
        public NarratorClip[] Clips;

        public AudioClip CurrentClip;

        public void Play(int ID)
        {
            if(GameStateManager.Instance.AudioState == AudioState.InSideTalk
               || GameStateManager.Instance.AudioState == AudioState.InMainTalk) return;
            
            GameStateManager.Instance.ChangeAudioState(AudioState.InSideTalk);
            AudioClip clip = GetClipByID(ID);
            SideSource.clip = clip;
            SideSource.Play();
            Invoke("ChangeState", SideSource.clip.length);
        }
        
        public void MainPlay(int ID)
        {
            if (GameManager.Instance.Data.Played(ID)) return;
            
            GameStateManager.Instance.ChangeAudioState(AudioState.InMainTalk);
            SideSource.Stop();
            MainSource.Stop();
            MainSource.clip = GetClipByID(ID);
            CurrentClip = MainSource.clip;
            MainSource.Play();
            Invoke("ChangeState", MainSource.clip.length);
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

#if UNITY_EDITOR
        private void Update()
        {
            if (Keyboard.current.enterKey.isPressed)
            {
                SideSource.Stop();
                MainSource.Stop();
                ChangeState();
            }
        }
#endif
        

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
        InSideTalk,
        InMainTalk
    }
}