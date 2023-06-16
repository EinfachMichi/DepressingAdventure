using System;
using Main;
using UnityEngine;

namespace Inventory_Items
{
    public class InventoryManager : Singleton<InventoryManager>
    {
        public Slot[] Slots;
        public GameObject SlotObject;

        private void Start()
        {
            int[] ItemIDs = GameManager.Instance.Data.InventoryInfo.ItemIDs;
            if (ItemIDs != null)
            {
                for (int i = 0; i < Slots.Length; i++)
                {
                    Slots[i].LoadData(ItemIDs[i]);
                }
            }

            GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
        }

        private void OnDisable()
        {
            GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;
        }

        private void OnGameStateChanged(GameState state)
        {
            if(state == GameState.Playing) SlotObject.SetActive(true);
            else SlotObject.SetActive(false);
        }

        public bool AddItem(ItemData data)
        {
            foreach (Slot slot in Slots)
            {
                if (slot.ItemData == null)
                {
                    slot.SetItem(data);
                    GameManager.Instance.SaveInventory(Slots);
                    return true;
                }
            }
            return false;
        }

        public void RemoveItem(int slotIndex)
        {
            if (slotIndex < 0 || slotIndex >= Slots.Length) return;
            
            Slots[slotIndex].Clear();
            GameManager.Instance.SaveInventory(Slots);
        }

        public bool HasItem(string name)
        {
            foreach (Slot slot in Slots)
            {
                if (slot.ItemData != null)
                {
                    if (slot.ItemData.Name == name)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}