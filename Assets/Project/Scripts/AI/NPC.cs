using System;
using System.Collections;
using Main;
using StorySystem;
using UnityEngine;
using UnityEngine.Events;

public class NPC : Interactable
{
    public Speaker speaker;
    public UnityEvent OnStoryEndEvent;
    private Story story;

    private void Awake()
    {
        story = new Story(speaker);
    }

    private void Start()
    {
        StoryManager.Instance.OnStoryEnd += OnStoryEnd;
    }
    
    public override void Interact()
    {
        if (story.HasStory())
        {
            StoryManager.Instance.RunStory(story);
            interactable = false;
        }
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
