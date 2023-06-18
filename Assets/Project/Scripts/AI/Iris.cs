using System;
using DialogSystem;
using Inventory_Items;
using Main;
using UnityEngine;

namespace AI
{
    public class Iris : NPC
    {
        private int choice;
        public GameObject brot;

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

            if (GameManager.Instance.Data.BrotPlaced)
            {
                brot.SetActive(true);
            }
        }

        private void Update()
        {
            if (!GameManager.Instance.Data.IrisNearTrigger
                && GameStateManager.Instance.AudioState != AudioState.InMainTalk)
            {
                Collider2D[] cols = Physics2D.OverlapCircleAll(
                    transform.position,
                    7f
                );
                foreach (Collider2D col in cols)
                {
                    if (col.CompareTag("Player"))
                    {
                        GameManager.Instance.Data.IrisNearTrigger = true;
                        Narrator.Instance.MainPlay(10);
                    }
                }
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
                Narrator.Instance.MainPlay(14);
                DialogIndex = 3;
            }
            else if (DialogIndex == 1 && choice == 1)
            {
                SceneHandler.Instance.EnterNewScene("Quest_01");
            }
            else if (DialogIndex == 5)
            {
                GameManager.Instance.Data.NpcInfos[5].DialogIndex = 4;
                InventoryManager.Instance.RemoveItem(3);
                GameManager.Instance.Data.BrotPlaced = true;
                brot.SetActive(true);
                DialogIndex = 4;
            }

            Invoke("ResetInteractable", 1f);
        }

        private void OnChoiceResults(int choice)
        {
            this.choice = choice;
        }
    }
}