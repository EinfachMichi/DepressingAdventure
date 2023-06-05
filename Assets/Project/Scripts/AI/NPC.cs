using System.Collections;
using DefaultNamespace;
using Main;
using UnityEngine;
using UnityEngine.Events;

public class NPC : MonoBehaviour, IInteractable
{
    public string Name;
    public UnityEvent OnDialogOver;
    private bool canInteract = true;
    private Story story;
    
    private void Start()
    {
        story = new Story(Name); 
        
        StoryManager.Instance.OnStoryEnd += OnStoryEnd;
    }
    
    public void Interact()
    {
        if (!canInteract) return;
        
        StoryManager.Instance.RunStory(story.GetStory());
        canInteract = false;
    }

    private void OnStoryEnd()
    {
        StartCoroutine(InteractionCooldown());
        OnDialogOver?.Invoke();
    }

    public void NextStory()
    {
        story.Next();
    }
    
    private IEnumerator InteractionCooldown()
    {
        canInteract = false;
        yield return new WaitForSeconds(1.5f);
        canInteract = true;
    }
}
