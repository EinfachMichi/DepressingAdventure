using ItemSystem;
using Main;

namespace InventorySystem
{
    public class Inventory : Singleton<Inventory>
    {
        public ItemSlot[] Slots;

        public void AddItem(Item newItem)
        {
            for (int i = 0; i < Slots.Length; i++)
            {
                if (Slots[i].IsSlotFull())//==true
                {
                    continue;
                }
                Slots[i].SetItem(newItem);
                return;
            }
        }

        public bool IsInvFull()
        {
            for(int i = 0; i < Slots.Length; i++)
            {
                if (Slots[i].IsSlotFull())//==true
                {
                    continue;
                }
                return false;//geht aus funktion
            }
            return true;
        }

    }

}
