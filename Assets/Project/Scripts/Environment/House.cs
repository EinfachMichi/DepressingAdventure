using System;
using Camera;
using UnityEngine;

namespace Environment
{
    public class House : MonoBehaviour
    {
        private Transform houseInTeleportPoint;
        private Transform houseOutTeleportPoint;
        private Transform player;
        private PolygonCollider2D border;
        private PolygonCollider2D defaultBorder;
        private MainCamera mainCam;

        private void Start()
        {
            player = GameObject.FindWithTag("Player").transform;
            border = GetComponentInChildren<PolygonCollider2D>();
            mainCam = MainCamera.Instance;
            houseInTeleportPoint = GameObject.FindWithTag("InTeleport").transform;
            houseOutTeleportPoint = GameObject.FindWithTag("OutTeleport").transform;
        }

        public void Teleport(DoorType type)
        {
            switch (type)
            {
                case DoorType.Out:
                    player.position = houseInTeleportPoint.position;
                    defaultBorder = (PolygonCollider2D) mainCam.Border();
                    mainCam.SetBorder(border);
                    break;
                case DoorType.In:
                    player.position = houseOutTeleportPoint.position;
                    mainCam.SetBorder(defaultBorder);
                    break;
            }
        }
    }
}