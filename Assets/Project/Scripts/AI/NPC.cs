using System;
using DialogSystem;
using Main;
using UnityEngine;

namespace AI
{
    public abstract class NPC : MonoBehaviour, IInteractable
    {
        protected NPCInfo info;
        public string Name;
        public Dialog[] Dialogs;

        protected virtual void Start()
        {
            if (GameManager.Instance.GetNPCInfo(Name, out NPCInfo info))
            {
                this.info = info;
            }
        }

        public bool interactable { get; set; } = true;
        protected void ResetInteractable() => interactable = true;
        public abstract void ShowInteraction();
        public abstract void Interaction();
        public abstract void EndInteraction();
    }
}