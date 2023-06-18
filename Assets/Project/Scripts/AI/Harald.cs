using AI;
using DialogSystem;
using Main;
using UnityEngine;

public class Harald : NPC
{
    public GameObject Barrier;
    public float NarratorTriggerRange;
    
    public override void Interaction()
    {
        if (!interactable) return;
        base.Interaction();

        interactable = false;
        DialogManager.Instance.OnDialogEnd += OnDialogEnd;
        DialogManager.Instance.StartDialog(Dialogs[DialogIndex]);
    }

    private void OnDialogEnd()
    {
        DialogManager.Instance.OnDialogEnd -= OnDialogEnd;

        if (DialogIndex == 0)
        {
            DialogIndex++;
            Barrier.SetActive(false);
            GameManager.Instance.Data.Barriers[2] = false;
            Narrator.Instance.MainPlay(9);
        }
        
        Invoke("ResetInteractable", 1f);
    }

    private void Update()
    {
        if (GameManager.Instance.Data.HaraldCanTriggerNarrator)
        {
            Collider2D col = Physics2D.OverlapCircle(
                transform.position,
                NarratorTriggerRange
            );
            
            if (col.CompareTag("Player"))
            {
                Narrator.Instance.MainPlay(6);
                GameManager.Instance.Data.HaraldCanTriggerNarrator = false;
            }
        }
    }
}