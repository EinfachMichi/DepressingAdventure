using System;
using Camera;
using Main;
using UnityEngine;
using UnityEngine.Serialization;

namespace Environment
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class House : MonoBehaviour, IInteractable
    {
        [FormerlySerializedAs("TeleportHouse")] public HouseInfo houseInfo;

        private Transform playerTransform;

        private void Awake()
        {
            playerTransform = GameObject.FindWithTag("Player").transform;
        }

        private void Start()
        {
            TeleportAnimation.Instance.OnTeleport += Teleport;
        }

        public void Interact()
        {
            TeleportAnimation.Instance.StartTeleportation();
        }

        private void Teleport()
        {
            playerTransform.position = houseInfo.TeleportationPoint.position;
            MainCamera.Instance.SetBoundary(houseInfo.Collider);
        }
    }
}