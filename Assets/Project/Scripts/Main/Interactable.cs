using UnityEngine;

namespace Main
{
    public abstract class Interactable : MonoBehaviour
    {
        public bool interactable { get; protected set; } = true;
        public abstract void Interact();
    }
}