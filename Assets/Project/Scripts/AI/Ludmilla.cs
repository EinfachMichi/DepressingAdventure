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

            if (InventoryManager.Instance.HasItem("WhiteRose"))
            {
                if (GameManager.Instance.Data.NpcInfos[2].DialogIndex == 6
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
        }

        public override void Interaction()
        {
            if (!interactable) return;
            base.Interaction();

            GameManager.Instance.Data.NarratorInfos[31].Played = true;
            
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

            if (DialogIndex == 3)
            {
                GameManager.Instance.Data.NpcInfos[2].DialogIndex = 7;
                Narrator.Instance.MainPlay(35);
            }

            Invoke("ResetInteractable", 1f);
        }

        public void Inspect()
        {
            DialogIndex = 2;
            DialogManager.Instance.OnNextSentence += OnNextSentence;
            DialogManager.Instance.StartDialog(Dialogs[2]);
            InventoryManager.Instance.RemoveItem(1);
            listQuest.SetActive(true);
        }

        private void OnNextSentence()
        {
            if (GameManager.Instance.Data.NpcInfos[3].DialogIndex == 3)
            {
                DialogManager.Instance.OnNextSentence -= OnNextSentence;
                OnInspectDone();
            }
        }
        
        public void OnInspectDone()
        {
            listQuest.SetActive(false);
            interactable = true;
            DialogIndex = 3;
            GameManager.Instance.Data.NpcInfos[2].DialogIndex = 7;
            GameManager.Instance.Data.CanCollectRose = true;
            GameManager.Instance.Save();
        }
    }
}