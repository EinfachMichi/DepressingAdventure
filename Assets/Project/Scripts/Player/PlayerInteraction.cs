using System;
using Environment;
using Main;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInteraction : MonoBehaviour
    {
        public float InteractionRadius;

        private bool canInteract = true;
        
        private void Start()
        {
            TeleportAnimation.Instance.OnTeleportAnimationStart += CanNotInteract;
            TeleportAnimation.Instance.OnTeleportAnimationDone += CanInteract;
        }

        private void CanInteract() => canInteract = true;
        private void CanNotInteract() => canInteract = false;
        
        public void Interaction(InputAction.CallbackContext value)
        {
            if (!value.started || !canInteract) return;
            
            Collider2D[] cols = Physics2D.OverlapCircleAll(
                transform.position,
                InteractionRadius
            );
            
            foreach (Collider2D col in cols)
            {
                if (col.TryGetComponent(out Interactable interactable))
                {
                    if (interactable.interactable)
                    {
                        interactable.Interact();
                    }
                }
            } 
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, InteractionRadius);
        }
    }
}