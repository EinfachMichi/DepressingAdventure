using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Main
{
    public class InteractableObject : MonoBehaviour, IInteractable
    {
        public UnityEvent startEvent;
        [Space]
        
        public List<UnityEvent> ShowInteractionEvents;
        public List<UnityEvent> InteractionEvents;
        public List<UnityEvent> EndInteractionEvents;

        public bool interactable { get; set; }

        protected virtual void Start()
        {
            interactable = true;
            startEvent.Invoke();
        }

        public virtual void ShowInteraction()
        {
            if (!interactable) return;
            foreach (UnityEvent unityEvent in ShowInteractionEvents)
            {
                unityEvent?.Invoke();
            }
        }

        public virtual void Interaction()
        {
            if (!interactable)
            {
                EndInteraction();
                return;
            }
            EndInteraction();
            foreach (UnityEvent unityEvent in InteractionEvents)
            {
                unityEvent?.Invoke();
            }
        }

        public virtual void EndInteraction()
        {
            foreach (UnityEvent unityEvent in EndInteractionEvents)
            {
                unityEvent?.Invoke();
            }
        }
        
        public void DisableObject(GameObject gameObject)
        {
            gameObject.SetActive(false);
        }

        public void EnableObject(GameObject gameObject)
        {
            gameObject.SetActive(true);
        }
    }
}