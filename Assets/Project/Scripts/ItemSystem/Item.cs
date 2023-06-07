using UnityEngine;
using UnityEngine.Events;

namespace ItemSystem
{
    public class Item : MonoBehaviour
    {
        public Items ItemTyp;
        public Sprite Icon;
        public UnityEvent OnInteract;

        // public override void Interact()
        // {
        //     if(Iventory.Instance.IsInvFull())
        //     {
        //         return;
        //     }
        //     gameObject.SetActive(false);
        //     Iventory.Instance.AddItem(this);
        //     OnInteract?.Invoke();
        // }
    }
}