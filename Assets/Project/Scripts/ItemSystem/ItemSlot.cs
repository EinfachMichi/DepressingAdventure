using System.Collections;
using System.Collections.Generic;
using ItemSystem;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Item Item;
    public Image Image;

    public bool IsSlotFull()
    {
        if (Item==null)
        {
            return false;
        }
        return true;
    }

    public void SetItem(Item newItem)
    {
        Item = newItem;
        Image.sprite = Item.Icon;
    } 
}
