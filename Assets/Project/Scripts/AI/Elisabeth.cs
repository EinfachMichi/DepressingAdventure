using DialogSystem;
using Inventory_Items;
using Main;

namespace AI
{
    public class Elisabeth : NPC
    {
        private int choice;
        public ItemData Brot;
        
        public override void Interaction()
        {
            if (!interactable) return;
            base.Interaction();

            if (DialogIndex == 1 || DialogIndex == 2)
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
            DialogManager.Instance.OnDialogEnd -= OnDialogEnd;

            if (DialogIndex == 1 && choice == 2 || DialogIndex == 2 && choice == 2)
            {
                DialogIndex = 3;
                GameManager.Instance.Data.NpcInfos[1].DialogIndex = 5;
                InventoryManager.Instance.AddItem(Brot);
            }
            else if (DialogIndex == 1 && choice == 1)
            {
                DialogIndex = 2;
            }
            else if (DialogIndex == 4)
            {
                DialogIndex = 5;
            }

            Invoke("ResetInteractable", 1f);
        }
    }
}