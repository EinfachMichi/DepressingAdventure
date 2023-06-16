using System;
using DialogSystem;
using Main;
using UnityEngine;

namespace AI
{
    public abstract class NPC : MonoBehaviour, IInteractable
    {
        public string Name;
        public Dialog[] Dialogs;
        protected NPCInfo info;

        protected int DialogIndex
        {
            get => info.DialogIndex;
            set => info.DialogIndex = value;
        }

        protected virtual void Start()
        {
            if (GameManager.Instance.GetNPCInfo(Name, out NPCInfo info))
            {
                this.info = info;
            }
        }

        public bool interactable { get; set; } = true;
        public abstract void ShowInteraction();
        public abstract void Interaction();
        public abstract void EndInteraction();
        protected void ResetInteractable() => interactable = true;
    }
}