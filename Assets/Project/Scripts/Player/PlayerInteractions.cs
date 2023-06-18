using System;
using Main;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInteractions : Freezer
    {
        public static bool CanInteract;
        
        public float InteractionRadius;

        private CapsuleCollider2D collider;

        private void Awake()
        {
            collider = GetComponent<CapsuleCollider2D>();
        }

        private void Start()
        {
            GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
            GameStateManager.Instance.OnAudioStateChanged += OnAudioStateChanged;
        }

        private void OnAudioStateChanged(AudioState obj)
        {
            if (obj == AudioState.InMainTalk) CanInteract = false;
            else CanInteract = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out IInteractable interactable))
            {
                interactable.EndInteraction();
            }
        }

        private void FixedUpdate()
        {
            Collider2D[] cols = Physics2D.OverlapCircleAll(
                transform.position,
                InteractionRadius
            );

            foreach (Collider2D col in cols)
            {
                if (col.TryGetComponent(out IInteractable interactable))
                {
                    if(CanInteract) interactable.ShowInteraction();
                }
            }
        }

        private void OnGameStateChanged(GameState state)
        {
            if(state == GameState.Playing)
            {
                UnFreeze();
                return;
            }
            
            Freeze();
        }

        /*
         * These methods are called by an UnityEvent from the new InputSystem
         */
        
        public void Interact(InputAction.CallbackContext context)
        {
            if (isFreezed || !CanInteract) return;
            
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