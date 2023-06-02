using System;
using System.Collections;
using DialogSystem;
using Main;
using UnityEngine;
using UnityEngine.Events;

public class NPC : MonoBehaviour, IInteractable
{
    public UnityEvent OnDialogOver;
    private bool canInteract = true;
    public int pid;
    
    private void Start()
    {
        DialogManager.Instance.OnDialogEnd += OnDialogEnd;
        
    }

    public void Interact()
    {
        if (!canInteract) return;
        
        DialogManager.Instance.StartDialog(pid);
        canInteract = false;
    }

    private void OnDialogEnd()
    {
        StartCoroutine(InteractionCooldown());
        OnDialogOver?.Invoke();
    }

    private IEnumerator InteractionCooldown()
    {
        canInteract = false;
        yield return new WaitForSeconds(1.5f);
        canInteract = true;
    }
}
