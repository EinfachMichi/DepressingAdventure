using System;
using UnityEngine;

namespace Main
{
    public class GameStateManager : Singleton<GameStateManager>
    {
        public event Action<GameState> OnGameStateChanged;
        public event Action<AudioState> OnAudioStateChanged;
        
        private GameState gameState;
        private AudioState audioState;

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
            gameState = newState;
            OnGameStateChanged?.Invoke(gameState);
        }

        public void ChangeAudioState(AudioState newState)
        {
            audioState = newState;
            OnAudioStateChanged?.Invoke(audioState);
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