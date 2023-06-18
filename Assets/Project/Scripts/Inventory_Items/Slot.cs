using System;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory_Items
{
    public class Slot : MonoBehaviour
    {
        public Image ItemIconImage;
        public ItemData ItemData;

        private void Awake()
        {
            Disable();
        }

        public void Clear()
        {
            ItemData = null;
            ItemIconImage.sprite = null;
            Disable();
        }

        public void SetItem(ItemData data)
        {
            ItemData = data;
            ItemIconImage.sprite = ItemData.Icon;
            Enable();
        }

        public int GetItemID()
        {
            if (ItemData == null) return 0;
            return ItemData.ID;
        }

        public void LoadData(int itemID)
        {
            if(itemID == 0)
            {
                Clear();
                return;
            }

            ItemData[] itemDatas = Resources.LoadAll<ItemData>("Items");
            foreach (ItemData data in itemDatas)
            {
                if (data.ID == itemID)
                {
                    SetItem(data);
                    Enable();
                    break;
                }
            }
        }

        public void Disable() => ItemIconImage.enabled = false;
        public void Enable() => ItemIconImage.enabled = true;
    }
}