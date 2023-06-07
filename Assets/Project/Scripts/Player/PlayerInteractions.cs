using System;
using Main;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInteractions : MonoBehaviour
    {
        public float InteractionRadius;

        private CapsuleCollider2D collider;

        private void Awake()
        {
            collider = GetComponent<CapsuleCollider2D>();
        }

        private void FixedUpdate()
        {
            CheckForInteractions();
        }

        private void CheckForInteractions()
        {
            foreach (Collider2D interact in GetCollidersInRadius(InteractionRadius))
            {
                if (interact.TryGetComponent(out InteractableObject interactable))
                {
                    interactable.ShowInteraction();
                }
            }
        }

        /*
         * These methods are called by an UnityEvent from the new InputSystem
         */
        
        public void Interact(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                foreach (Collider2D other in GetCollidersInRadius(InteractionRadius))
                {
                    if (other.TryGetComponent(out IInteractable interactable))
                    {
                        if (interactable.interactable)
                        {
                            interactable.Interaction();
                        }
                    }
                }
            }
        }

        #region Helpers

        private Collider2D[] GetCollidersInRadius(float radius)
        {
            return Physics2D.OverlapCircleAll(
                (Vector2) transform.position + collider.offset,
                radius
            );
        }

        #endregion
        
#if UNITY_EDITOR
        
        public bool DrawInteractionRadius;   
        
        private void OnDrawGizmos()
        {
            Vector3 offset = new Vector3(0f, 0.5f);

            if (DrawInteractionRadius)
            {
                Gizmos.color = Color.white;
                Gizmos.DrawWireSphere(
                    transform.position + offset, 
                    InteractionRadius
                );
            }
        }
#endif
    }
}