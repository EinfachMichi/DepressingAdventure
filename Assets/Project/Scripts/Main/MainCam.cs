using Cinemachine;
using UnityEngine;

namespace Main
{
    public class MainCam : MonoBehaviour
    {
        private CinemachineConfiner confiner;
        private CinemachineVirtualCamera cam;
        private Transform player;

        private void Awake()
        {
            confiner = GetComponentInChildren<CinemachineConfiner>();
            cam = GetComponentInChildren<CinemachineVirtualCamera>();
            player = GameObject.FindWithTag("Player").transform;

            cam.Follow = player;

            PolygonCollider2D col = GameObject.FindWithTag("MapBorder").GetComponent<PolygonCollider2D>();
            confiner.m_BoundingShape2D = col;
        }
    }
}