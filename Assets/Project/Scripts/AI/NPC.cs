using System;
using System.Collections;
using System.Collections.Generic;
using DialogSystem;
using Main;
using QuestSystem;
using UnityEngine;
using UnityEngine.Events;

public class NPC : MonoBehaviour, IInteractable
{
    public string Name;
    public UnityEvent OnDialogOver;
    private bool canInteract = true;

    private List<Conversation> casualConversations = new List<Conversation>();
    private List<Conversation> quests = new List<Conversation>();
    private List<Conversation> questsDone = new List<Conversation>();

    private void Start()
    {
        DialogManager.Instance.OnDialogEnd += OnDialogEnd;

        DialogManager.Instance.GetConversation(Name, "Start");
    }

    public void Interact()
    {
        if (!canInteract) return;
        
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
