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
        public House houseInfo;

        private Transform playerTransform;

        private void Awake()
        {
            playerTransform = GameObject.FindWithTag("Player").transform;
        }

        public void Interact()
        {
            TeleportAnimation.Instance.OnTeleport += Teleport;
            TeleportAnimation.Instance.StartTeleportation();
        }

        private void Teleport()
        {
            TeleportAnimation.Instance.OnTeleport -= Teleport;
            playerTransform.position = houseInfo.TeleportationPoint.position;
            MainCamera.Instance.SetBoundary(houseInfo.CameraBorder);
        }
    }
}