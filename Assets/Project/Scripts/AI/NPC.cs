using System;
using System.Collections;
using DialogSystem;
using Main;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    public Dialog Dialog;

    private bool canInteract = true;

    public void Interact()
    {
        if (!canInteract) return;
        
        canInteract = false;
        DialogManager.Instance.StartDialog(Dialog);
        DialogManager.Instance.OnDialogEnd += OnDialogEnd;
    }

    private void OnDialogEnd()
    {
        DialogManager.Instance.OnDialogEnd -= OnDialogEnd;
        StartCoroutine(InteractionCooldown());
    }

    private IEnumerator InteractionCooldown()
    {
        canInteract = false;
        yield return new WaitForSeconds(1.5f);
        canInteract = true;
    }
}
