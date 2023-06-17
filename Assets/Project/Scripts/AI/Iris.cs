using DialogSystem;
using Main;

namespace AI
{
    public class Iris : NPC
    {
        private int choice;

        protected override void Start()
        {
            base.Start();

            Invoke("LateStart", 0.2f);
        }

        private void LateStart()
        {
            if (DialogIndex == 1)
            {
                DialogManager.Instance.OnChoiceResults += OnChoiceResults;
                DialogManager.Instance.OnDialogEnd += OnDialogEnd;
                DialogManager.Instance.StartDialog(Dialogs[1]);
            }
        }

        public override void Interaction()
        {
            if (!interactable) return;
            base.Interaction();
            
            interactable = false;

            if (DialogIndex == 0 || DialogIndex == 2 || DialogIndex == 1)
            {
                DialogManager.Instance.OnChoiceResults += OnChoiceResults;
            }
            
            DialogManager.Instance.OnDialogEnd += OnDialogEnd;
            DialogManager.Instance.StartDialog(Dialogs[DialogIndex]);
        }

        private void OnDialogEnd()
        {
            DialogManager.Instance.OnDialogEnd -= OnDialogEnd;
            DialogManager.Instance.OnChoiceResults -= OnChoiceResults;

            if (DialogIndex == 0 && choice == 2)
            {
                DialogIndex = 1;
                SceneHandler.Instance.EnterNewScene("Quest_01");
            }
            else if (DialogIndex == 0 && choice == 1)
            {
                DialogIndex = 2;
            }
            else if (DialogIndex == 2 && choice == 2)
            {
                DialogIndex = 1;
                SceneHandler.Instance.EnterNewScene("Quest_01");
            }
            else if (DialogIndex == 1 && choice == 2)
            {
                GameManager.Instance.Data.NpcInfos[2].DialogIndex = 1;
                DialogIndex = 3;
            }

            Invoke("ResetInteractable", 1f);
        }

        private void OnChoiceResults(int choice)
        {
            this.choice = choice;
        }
    }
}