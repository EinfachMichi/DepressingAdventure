using Main;
using UnityEngine;

namespace Environment
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Door : Interactable
    {
        public DoorType Type;
        private House house;

        private void Awake()
        {
            house = GetComponentInParent<House>();
        }

        public override void Interact()
        {
            print("Test1");
            if (!interactable) return;
            print("Test2");
            
            TeleportAnimation.Instance.OnTeleport += Teleport;
            TeleportAnimation.Instance.StartTeleportation();
        }

        private void Teleport()
        {
            TeleportAnimation.Instance.OnTeleport -= Teleport;
            house.Teleport(Type);
        }
    }

    public enum DoorType
    {
        In,
        Out
    }
}