using DialogSystem;
using Main;

namespace AI
{
    public class Harald : NPC
    {
        public override void ShowInteraction()
        {
        }

        public override void Interaction()
        {
            interactable = false;
            DialogManager.Instance.OnDialogEnd += OnDialogEnd;
            DialogManager.Instance.StartDialog(Dialogs[info.DialogIndex]);
        }

        public override void EndInteraction()
        {
        }

        private void OnDialogEnd()
        {
            DialogManager.Instance.OnDialogEnd -= OnDialogEnd;
            info.DialogIndex++;
            if(info.DialogIndex > 1)
            {
                info.DialogIndex = 1;
            }
            Invoke("ResetInteractable", 1f);
        }
    }
}