using System;
using Main;
using UnityEngine;

namespace AI
{
    public abstract class NPC : MonoBehaviour, IInteractable
    {
        protected Animator anim;
        public bool interactable { get; set; }

        private void Awake()
        {
            anim = GetComponent<Animator>();
        }

        public void ShowInteraction()
        {
            
        }

        public abstract void Interaction();
    }
}