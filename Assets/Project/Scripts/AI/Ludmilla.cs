using DialogSystem;
using Inventory_Items;
using Main;
using UnityEngine;

namespace AI
{
    public class Ludmilla : NPC
    {
        private int choice;
        public GameObject listQuest;
        
        protected override void Start()
        {
            base.Start();
            if (GameManager.Instance.Data.LudmillaDead) return;
            
            if (InventoryManager.Instance.HasItem("WhiteRose"))
            {
                gameObject.SetActive(false);
                if (!GameManager.Instance.Data.LudmillaDead)
                {
                    GameManager.Instance.Data.LudmillaDead = true;
                    GameManager.Instance.Data.WitchVillage = true;
                }
            }
        }

        public override void Interaction()
        {
            if (!interactable) return;
            base.Interaction();

            if (DialogIndex == 0)
            {
                DialogManager.Instance.OnChoiceResults += OnChoiceResults;
            }
            
            interactable = false;
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

            if (DialogIndex == 0 && choice == 2)
            {
                Inspect();
            }
            else if (DialogIndex == 0 && choice == 1)
            {
                DialogIndex = 4;
            }
            
            Invoke("ResetInteractable", 1f);
        }

        public void Inspect()
        {
            listQuest.SetActive(true);
            GameStateManager.Instance.ChangeState(GameState.InList);
        }
        
        public void OnInspectDone()
        {
            DialogIndex = 2;
            listQuest.SetActive(false);
            Interaction();
        }
    }
}