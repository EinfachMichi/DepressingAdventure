using System;
using UnityEngine;

namespace Main
{
    public class GameStateManager : Singleton<GameStateManager>
    {
        public event Action<GameState> OnGameStateChanged;
        public event Action<AudioState> OnAudioStateChanged;
        
        public GameState GameState;
        public AudioState AudioState;

        private void Start()
        {
            Invoke("PlayingState", 0.2f);
        }

        private void PlayingState()
        {
            ChangeGameState(GameState.Playing);
        }

        public void ChangeGameState(GameState newState)
        {
            GameState = newState;
            OnGameStateChanged?.Invoke(GameState);
        }

        public void ChangeAudioState(AudioState newState)
        {
            AudioState = newState;
            OnAudioStateChanged?.Invoke(AudioState);
        }
    }

    public enum GameState
    {
        Playing,
        InDialog,
        InMap,
        InList,
        InTeleportation
    }
}