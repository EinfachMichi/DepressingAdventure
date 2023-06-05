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
        public LayerMask InteractionLayer;

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
                InteractionRadius,
                InteractionLayer
            );

            foreach (Collider2D col in cols)
            {
                if(col.CompareTag("Player")) continue;
                
                col.GetComponent<Interactable>().Interact();
            } 
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, InteractionRadius);
        }
    }
}