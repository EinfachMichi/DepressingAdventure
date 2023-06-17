using DialogSystem;
using Main;

namespace Environment
{
    public class DialogObject : InteractableObject
    {
        public Dialog dialog;

        public void ReadDialog()
        {
            if (!interactable) return;

            interactable = false;
            DialogManager.Instance.OnDialogEnd += OnDialogEnd;
            DialogManager.Instance.StartDialog(dialog);
        }

        private void OnDialogEnd()
        {
            DialogManager.Instance.OnDialogEnd -= OnDialogEnd;
            
            Invoke("ResetInteractable", 1f);   
        }

        private void ResetInteractable()
        {
            interactable = true;
        }
    }
}