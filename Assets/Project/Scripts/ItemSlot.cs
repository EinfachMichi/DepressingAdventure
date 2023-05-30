using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    public Items Item=Items.None;

    public bool IsSlotFull()
    {
        if (Item == Items.None)
        {
            return false;
        }
        return true;
    }

    public void SetItem(Items newItem)
    {
        Item = newItem;   
    } 
}
