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