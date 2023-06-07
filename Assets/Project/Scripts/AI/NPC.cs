using System;
using DialogSystem;
using Main;
using UnityEngine;

namespace AI
{
    public class NPC : MonoBehaviour, IInteractable
    {
        public bool interactable { get; set; }
        public Speaker speaker;

        private void Start()
        {
            interactable = true;
        }

        public void ShowInteraction()
        {
        
        }

        public void Interaction()
        {
            print($"You interacted with {speaker.Name}.");
        }
    }
}