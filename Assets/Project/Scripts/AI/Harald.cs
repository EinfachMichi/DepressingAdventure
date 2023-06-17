using AI;
using DialogSystem;

public class Harald : NPC
{
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
        }
        
        Invoke("ResetInteractable", 1f);
    }
}
