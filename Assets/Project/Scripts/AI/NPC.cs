using System;
using System.Collections;
using DialogSystem;
using Main;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    private bool canInteract = true;
    public int pid;

    public void Interact()
    {
        if (!canInteract) return;
        
        DialogManager.Instance.StartDialog(pid);
        canInteract = false;
    }

    private void OnDialogEnd()
    {
        StartCoroutine(InteractionCooldown());
    }

    private IEnumerator InteractionCooldown()
    {
        canInteract = false;
        yield return new WaitForSeconds(1.5f);
        canInteract = true;
    }
}
