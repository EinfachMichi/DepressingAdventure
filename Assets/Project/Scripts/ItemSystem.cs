using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSystem : MonoBehaviour
{

    public Items Item;

    private void Start()
    {
        switch (Item)
        {
            case Items.Stock:
                break;
            case Items.Stein:
                break;
            case Items.Papier:
                break;
            case Items.Karte:
                break;
        }
    }
}
public enum Items
{
    None,//0
    Stock,//1
    Stein,//2
    Papier,//3
    Karte,//4
}
