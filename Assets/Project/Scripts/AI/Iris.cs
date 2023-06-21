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
            if (DialogIndex == 1 && !GameManager.Instance.Data.Q1PlayerWon)
            {
                DialogManager.Instance.OnDialogEnd += OnDialogEnd;
                DialogIndex = 3;
                DialogManager.Instance.StartDialog(Dialogs[3]);
                interactable = false;
            }
            else if (DialogIndex == 1 && GameManager.Instance.Data.Q1PlayerWon)
            {
                DialogIndex = 6;
            }

            if (GameManager.Instance.Data.BrotPlaced)
            {
                brot.SetActive(true);
                InventoryManager.Instance.RemoveItem(2);
            }
        }

        private void Update()
        {
            print(DialogIndex);
            if (!GameManager.Instance.Data.IrisNearTrigger
                && GameStateManager.Instance.AudioState != AudioState.InMainTalk)
            {
                Collider2D[] cols = Physics2D.OverlapCircleAll(
                    transform.position,
                    5f
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
            else if (DialogIndex == 3)
            {
                GameManager.Instance.Data.NpcInfos[2].DialogIndex = 1;
                Narrator.Instance.MainPlay(14);
                Invoke("NextNarr", Narrator.Instance.CurrentClip.length + 1f);
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

        private void NextNarr()
        {
            Narrator.Instance.MainPlay(23);
            Invoke("NextNarrTime", Narrator.Instance.CurrentClip.length + 7f);
        }

        private void NextNarrTime()
        {
            Narrator.Instance.MainPlay(24);
        }
        
        private void OnChoiceResults(int choice)
        {
            this.choice = choice;
        }
    }
}