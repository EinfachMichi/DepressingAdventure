using DialogSystem;
using Inventory_Items;
using Main;

namespace AI
{
    public class Fronicka : NPC
    {
        public ItemData List;

        private int choice;
        
        public override void Interaction()
        {
            if (!interactable) return;
            base.Interaction();

            interactable = false;

            if (DialogIndex == 1 || DialogIndex == 3)
            {
                DialogManager.Instance.OnChoiceResults += OnChoiceResults;
            }
            
            DialogManager.Instance.OnDialogEnd += OnDialogEnd;
            DialogManager.Instance.StartDialog(Dialogs[DialogIndex]);
        }

        private void OnChoiceResults(int choice)
        {
            this.choice = choice;
        }

        private void OnDialogEnd()
        {
            DialogManager.Instance.OnChoiceResults -= OnChoiceResults;
            DialogManager.Instance.OnDialogEnd -= OnDialogEnd;

            if (DialogIndex == 1 && choice == 2 || DialogIndex == 3 && choice == 2)
            {
                GameManager.Instance.Data.Barriers[1] = false;
                InventoryManager.Instance.AddItem(List);
                DialogIndex = 6;
            }
            else if (DialogIndex == 1 && choice == 1)
            {
                DialogIndex = 3;
            }

            Invoke("ResetInteractable", 1f);
        }
    }
}