using System;
using DialogSystem;
using Inventory_Items;
using Main;
using UnityEngine;

namespace Environment
{
    public class Barrier : MonoBehaviour
    {
        public int ID;
        public bool Active;
        public Dialog dialog;
        public Vector2 pushDirection;
        public int NarratorID;
        public bool HaraldTrigger;

        private Transform player;
        
        private void Start()
        {
            Active = GameManager.Instance.Data.Barriers[ID];
            if (Active)
            {
                gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                player = col.gameObject.transform;
                if (GameManager.Instance.Data.NpcInfos[0].DialogIndex == 0 
                    && InventoryManager.Instance.HasItem("Map") 
                    && GameStateManager.Instance.AudioState != AudioState.InMainTalk
                    && HaraldTrigger)
                {
                    Narrator.Instance.MainPlay(7);
                }
                else
                {
                    Narrator.Instance.Play(NarratorID);
                }
                DialogManager.Instance.OnDialogEnd += OnDialogEnd;
                DialogManager.Instance.StartDialog(dialog);
            }
        }

        public void Disable()
        {
            gameObject.SetActive(false);
            Active = false;
            GameManager.Instance.Data.Barriers[ID] = false;
        }
        
        private void OnDialogEnd()
        {
            DialogManager.Instance.OnDialogEnd -= OnDialogEnd;
            player.position += (Vector3) pushDirection;
        }
    }
}