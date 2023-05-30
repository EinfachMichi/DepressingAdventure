using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main;

public class Iventory : Singleton<Iventory>
{
    public ItemSlot[] Slots;
    public bool InvFull=false;

    public void AddItem(Items newItem)
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
