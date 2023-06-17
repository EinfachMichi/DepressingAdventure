using DialogSystem;

namespace AI
{
    public class Nikolaus : NPC
    {
        public override void Interaction()
        {
            if (!interactable) return;
            base.Interaction();
            
            DialogManager.Instance.OnDialogEnd += OnDialogEnd;
            DialogManager.Instance.StartDialog(Dialogs[DialogIndex]);
        }

        private void OnDialogEnd()
        {
            DialogManager.Instance.OnDialogEnd -= OnDialogEnd;

            if (DialogIndex == 0)
            {
                DialogIndex = 1;
            }
            
            Invoke("ResetInteractable", 1f);
        }
    }
}