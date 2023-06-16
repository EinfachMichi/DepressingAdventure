using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Main
{
    public class InteractableObject : MonoBehaviour, IInteractable
    {
        public List<UnityEvent> ShowInteractionEvents;
        public List<UnityEvent> InteractionEvents;
        public List<UnityEvent> EndInteractionEvents;

        public bool interactable { get; set; }

        protected virtual void Start()
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

        public void EndInteraction()
        {
            foreach (UnityEvent unityEvent in EndInteractionEvents)
            {
                unityEvent?.Invoke();
            }
        }
    }
}