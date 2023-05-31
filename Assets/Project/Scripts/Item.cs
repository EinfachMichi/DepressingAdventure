using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main;

public class Item : MonoBehaviour,IInteractable
{
    public Items GameobjectItem;

    public void Interact()
    {
        if(Iventory.Instance.IsInvFull())
        {
            return;
        }
        gameObject.SetActive(false);
        Iventory.Instance.AddItem(GameobjectItem);
        print("Test");
    }  
}
