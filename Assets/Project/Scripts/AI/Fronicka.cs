using DialogSystem;
using Inventory_Items;
using Main;
using UnityEngine.Events;

namespace AI
{
    public class Fronicka : NPC
    {
        public ItemData List;
        
        public override void ShowInteraction()
        {
        
        }

        public override void Interaction()
        {
            if (!interactable) return;

            interactable = false;
            DialogManager.Instance.OnDialogEnd += OnDialogEnd;
            DialogManager.Instance.StartDialog(Dialogs[DialogIndex]);
        }

        private void OnDialogEnd()
        {
            DialogManager.Instance.OnDialogEnd -= OnDialogEnd;

            if (DialogIndex == 0)
            {
                GameManager.Instance.Data.Barriers[1] = false;
                InventoryManager.Instance.AddItem(List);
                DialogIndex++;
            }
            
            Invoke("ResetInteractable", 1f);
        }

        public override void EndInteraction()
        {
            
        }
    }
}