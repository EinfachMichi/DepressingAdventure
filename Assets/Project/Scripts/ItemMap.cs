using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main;

public class MapScript : Event,IInteractable
{
    public void Interact()
    {
        TriggerEvent();
    }
}
