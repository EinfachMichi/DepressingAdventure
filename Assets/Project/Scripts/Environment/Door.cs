using System;
using Camera;
using Main;
using UnityEngine;
using UnityEngine.Serialization;

namespace Environment
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Door : MonoBehaviour, IInteractable
    {
        public DoorType Type;
        
        private House house;

        private void Awake()
        {
            house = GetComponentInParent<House>();
        }

        public void Interact()
        {
            if (TeleportAnimation.Instance.isTeleporting) return;
            
            TeleportAnimation.Instance.StartTeleportation();
            TeleportAnimation.Instance.OnTeleport += Teleport;
        }

        private void Teleport()
        {
            house.Teleport(Type);
            TeleportAnimation.Instance.OnTeleport -= Teleport;
        }
    }

    public enum DoorType
    {
        In,
        Out
    }
}