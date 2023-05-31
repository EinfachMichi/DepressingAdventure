using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main;

public class Item : MonoBehaviour,IInteractable
{
    public Items ItemTyp;
    public Sprite Icon;

    public void Interact()
    {
        if(Iventory.Instance.IsInvFull())
        {
            return;
        }
        gameObject.SetActive(false);
        Iventory.Instance.AddItem(this);
        print("Test");
    }  
}
