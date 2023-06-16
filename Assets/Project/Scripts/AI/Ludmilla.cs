using System.Collections;
using System.Collections.Generic;
using DialogSystem;
using UnityEngine;

namespace AI
{
    public class Ludmilla : NPC
    {
        public override void ShowInteraction()
        {
            
        }

        public override void Interaction()
        {
            if (!interactable) return;

            interactable = false;
            DialogManager.Instance.OnDialogEnd += OnDialogEnd;
            DialogManager.Instance.StartDialog(Dialogs[DialogIndex]);
        }

        private void OnDialogEnd()
        {
            DialogManager.Instance.OnDialogEnd -= OnDialogEnd;
            
            
            
            Invoke("ResetInteractable", 1f);
        }

        public override void EndInteraction()
        {
            
        }
    }
}