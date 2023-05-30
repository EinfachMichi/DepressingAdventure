using DialogSystem;
using Main;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    public Dialog Dialog;
    
    public void Interact()
    {
        DialogManager.Instance.StartDialog(Dialog);
    }
}
