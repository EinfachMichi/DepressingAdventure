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

        public bool interactable { get; set; } = true;
        public abstract void ShowInteraction();
        public abstract void Interaction();
        public abstract void EndInteraction();
    }
}