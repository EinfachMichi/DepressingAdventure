using System.Collections;
using Main;
using StorySystem;
using UnityEngine;
using UnityEngine.Events;

public class NPC : Interactable
{
    public Speaker speaker;
    public UnityEvent OnStoryEndEvent;
    private bool canInteract = true;
    private Story story;
    
    private void Start()
    {
        story = new Story(speaker);

        StoryManager.Instance.OnStoryEnd += OnStoryEnd;
    }
    
    public override void Interact()
    {
        if (!interactable) return;
        
        interactable = false;
        StoryManager.Instance.RunStory(story);
    }

    private void OnStoryEnd()
    {
        OnStoryEndEvent?.Invoke();
        StartCoroutine(InteractionCooldown());
    }

    public void NextStory()
    {
        story.Next();
    }
    
    private IEnumerator InteractionCooldown()
    {
        interactable = false;
        yield return new WaitForSeconds(1.5f);
        interactable = true;
    }
}
