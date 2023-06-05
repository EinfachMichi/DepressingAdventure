using System;
using Main;
using UnityEngine;

namespace Player
{
    public class PlayerInteraction : MonoBehaviour
    {
        public float InteractionRadius;
        public LayerMask InteractionLayer;

        private void Update()
        {
            
        }

        private void Interaction()
        {
            Collider2D[] cols = Physics2D.OverlapCircleAll(
                transform.position,
                InteractionRadius,
                InteractionLayer
            );

            foreach (Collider2D col in cols)
            {
                if(col.CompareTag("Player")) continue;
                
                col.GetComponent<IInteractable>().Interact();
            }   
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, InteractionRadius);
        }
    }
}