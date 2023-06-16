using DialogSystem;
using Main;

namespace AI
{
    public class Iris : NPC
    {
        protected override void Start()
        {
            base.Start();

            if (DialogIndex == 1)
            {
                DialogManager.Instance.OnChoiceResults += OnChoiceResults;
                DialogManager.Instance.StartDialog(Dialogs[1]);
            }
        }

        public override void Interaction()
        {
            if (!interactable) return;
            
            interactable = false;
            if (DialogIndex == 0)
            {
                DialogManager.Instance.OnDialogEnd += OnDialogEnd;
                DialogManager.Instance.StartDialog(Dialogs[DialogIndex]);
            }

            if (DialogIndex == 2)
            {
                DialogManager.Instance.OnDialogEnd += OnDialogEnd;
                DialogManager.Instance.StartDialog(Dialogs[DialogIndex]);
            }
        }

        private void OnDialogEnd()
        {
            DialogManager.Instance.OnDialogEnd -= OnDialogEnd;
            
            if (DialogIndex == 0)
            {
                DialogManager.Instance.OnDialogEnd += OnDialogEnd;
                DialogIndex++;
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
                DialogIndex++;
                Invoke("ResetInteractable", 1f);
            }
        }
    }
}