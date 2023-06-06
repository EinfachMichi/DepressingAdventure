using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Main
{
    public class InteractableObject : MonoBehaviour, IInteractable
    {
        public List<UnityEvent> ShowInteractionEvents;
        public List<UnityEvent> InteractionEvents;

        public bool interactable { get; set; }

        private void Start()
        {
            interactable = true;
        }

        public void ShowInteraction()
        {
            foreach (UnityEvent unityEvent in ShowInteractionEvents)
            {
                unityEvent?.Invoke();
            }
        }

        public void Interaction()
        {
            foreach (UnityEvent unityEvent in InteractionEvents)
            {
                unityEvent?.Invoke();
            }
        }
    }
}