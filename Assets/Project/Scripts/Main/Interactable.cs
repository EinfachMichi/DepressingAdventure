using UnityEngine;

namespace Main
{
    public abstract class Interactable : MonoBehaviour
    {
        protected bool interactable = true;
        public abstract void Interact();
    }
}