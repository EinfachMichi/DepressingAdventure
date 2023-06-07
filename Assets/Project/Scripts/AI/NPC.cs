using System;
using DialogSystem;
using Main;
using UnityEngine;
using UnityEngine.Events;

namespace AI
{
    public class NPC : MonoBehaviour, IInteractable
    {
        [SerializeField] private new string name;   
        
        public Dialog[] Dialogs;
        public UnityEvent[] DialogOverEvent;
        public string Name => name;
        public bool interactable { get; set; } = true;

        private int dialogIndex;

        public void Interaction()
        {
            if (Dialogs.Length == 0) return;
            
            DialogManager.Instance.StartDialog(Dialogs[dialogIndex]);
            interactable = false;
            DialogManager.Instance.OnDialogEnd += OnDialogEnd;
        }

        public void ShowInteraction()
        {
            
        }

        private void OnDialogEnd()
        {
            interactable = true;
            DialogOverEvent[dialogIndex].Invoke();
            dialogIndex++;
        }
    }
}