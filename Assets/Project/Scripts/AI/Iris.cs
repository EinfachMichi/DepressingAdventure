using DialogSystem;
using Main;

namespace AI
{
    public class Iris : NPC
    {
        protected override void Start()
        {
            base.Start();
            if (info.DialogIndex == 1)
            {
                DialogManager.Instance.OnChoiceResults += OnChoiceResults;
                DialogManager.Instance.StartDialog(Dialogs[1]);
            }
        }

        public override void ShowInteraction()
        {
            
        }

        public override void Interaction()
        {
            if (!interactable) return;
            
            interactable = false;
            if (info.DialogIndex == 0)
            {
                DialogManager.Instance.OnDialogEnd += OnDialogEnd;
                DialogManager.Instance.StartDialog(Dialogs[info.DialogIndex]);
            }

            if (info.DialogIndex == 2)
            {
                DialogManager.Instance.OnDialogEnd += OnDialogEnd;
                DialogManager.Instance.StartDialog(Dialogs[info.DialogIndex]);
            }
        }

        public override void EndInteraction()
        {
        }

        private void OnDialogEnd()
        {
            DialogManager.Instance.OnDialogEnd -= OnDialogEnd;
            
            if (info.DialogIndex == 0)
            {
                DialogManager.Instance.OnDialogEnd += OnDialogEnd;
                info.DialogIndex++;
                SceneHandler.Instance.EnterNewScene("Quest_01");
            }

            Invoke("ResetInteractable", 1f);
        }

        private void OnChoiceResults(int choice)
        {
            DialogManager.Instance.OnChoiceResults -= OnChoiceResults;
            if (choice == 1)
            {
                SceneHandler.Instance.EnterNewScene("Quest_01");
            }
            else
            {
                info.DialogIndex++;
                Invoke("ResetInteractable", 1f);
            }
        }
    }
}