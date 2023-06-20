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

            if (InventoryManager.Instance.HasItem("WhiteRose")
                && GameManager.Instance.Data.NpcInfos[2].DialogIndex == 6
                || GameManager.Instance.Data.NpcInfos[2].DialogIndex == 8
                || GameManager.Instance.Data.NpcInfos[2].DialogIndex == 7)
            {
                gameObject.SetActive(false);
                if (!GameManager.Instance.Data.LudmillaDead)
                {
                    GameManager.Instance.Data.LudmillaDead = true;
                    GameManager.Instance.Data.WitchVillage = true;
                    GameManager.Instance.Save();
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

            Invoke("ResetInteractable", 1f);
        }

        public void Inspect()
        {
            DialogManager.Instance.OnNextSentence += OnInspectDone;
            DialogManager.Instance.StartDialog(Dialogs[2]);
            GameStateManager.Instance.ChangeGameState(GameState.InList);
            InventoryManager.Instance.RemoveItem(1);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            listQuest.SetActive(true);
        }
        
        public void OnInspectDone()
        {
            DialogManager.Instance.OnNextSentence -= OnInspectDone;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            DialogIndex = 2;
            listQuest.SetActive(false);
            interactable = true;
            DialogIndex = 3;
            GameManager.Instance.Data.NpcInfos[2].DialogIndex = 7;
            GameManager.Instance.Data.CanCollectRose = true;
            GameManager.Instance.Save();
        }
    }
}