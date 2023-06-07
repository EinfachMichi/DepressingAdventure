using System;
using DialogSystem;
using Main;
using UnityEngine;

namespace AI
{
    public class NPC : MonoBehaviour, IInteractable
    {
        [SerializeField] private new string name;   
        
        public Dialog[] Dialogs;
        public string Name => name;
        public bool interactable { get; set; } = true;

        public void Interaction()
        {
            if (Dialogs.Length == 0) return;
            
            DialogManager.Instance.StartDialog(Dialogs[0]);
            interactable = false;
            DialogManager.Instance.OnDialogEnd += OnDialogEnd;
        }

        public void ShowInteraction()
        {
            
        }

        private void OnDialogEnd()
        {
            interactable = true;
        }
    }
}