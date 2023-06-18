using Inventory_Items;
using Main;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Other
{
    public class MapManager : MonoBehaviour
    {
        public GameObject mapUI;

        private bool canOpen;
        
        private void Start()
        {
            canOpen = true;
            mapUI.SetActive(false);
            GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
        }

        private void OnGameStateChanged(GameState state)
        {
            if (state == GameState.Playing || state == GameState.InMap) canOpen = true;
            else canOpen = false;
        }

        private void OnDisable()
        {
            GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;
        }

        public void OnMPressed(InputAction.CallbackContext context)
        {
            if (!canOpen || !InventoryManager.Instance.HasItem("Map")) return;

            if (context.started)
            {
                mapUI.SetActive(!mapUI.activeSelf);
                if(mapUI.activeSelf)
                {
                    GameStateManager.Instance.ChangeGameState(GameState.InMap);
                    AudioManager.Instance.StopAllSounds(AudioManager.AudioSound.EffectSounds);
                }
                else GameStateManager.Instance.ChangeGameState(GameState.Playing);
            }
        }
    }
}