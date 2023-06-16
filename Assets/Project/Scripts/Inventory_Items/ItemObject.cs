using System;
using Main;

namespace Inventory_Items
{
    public class ItemObject : InteractableObject
    {
        public ItemData Data;

        private ItemInfo info;

        protected override void Start()
        {
            base.Start();

            ItemInfo[] infos = GameManager.Instance.Data.ItemInfos;
            foreach (ItemInfo info in infos)
            {
                if (info.ItemID == Data.ID)
                {
                    this.info = info;
                    if(info.Active) gameObject.SetActive(true);
                    else gameObject.SetActive(false);
                    break;
                }
            }

            if (info == null)
            {
                info = new ItemInfo();
                info.ItemID = Data.ID;
                info.Active = true;
                GameManager.Instance.SaveItemInfo(info);
                GameManager.Instance.Save();
            }
        }

        public void Interaction()
        {
            if (InventoryManager.Instance.AddItem(Data))
            {
                info.Active = false;
                GameManager.Instance.SaveItemInfo(info);
                GameManager.Instance.Save();
                Destroy(gameObject);
            }
        }
    }
}