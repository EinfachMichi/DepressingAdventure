using System;
using UnityEngine;

namespace Main
{
    public class GameStateManager : Singleton<GameStateManager>
    {
        public event Action<GameState> OnGameStateChanged;
        
        private GameState state;

        private void Start()
        {
            Invoke("PlayingState", 0.2f);
        }

        private void PlayingState()
        {
            ChangeState(GameState.Playing);
        }

        public void ChangeState(GameState newState)
        {
            state = newState;
            OnGameStateChanged?.Invoke(state);
        }
    }

    public enum GameState
    {
        Playing,
        InDialog,
        InMap,
        InTeleportation
    }
}