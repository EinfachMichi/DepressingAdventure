using System;
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
            cam = GetComponentInChildren<CinemachineVirtualCamera>();
            confiner = GetComponentInChildren<CinemachineConfiner>();
            player = GameObject.FindWithTag("Player").transform;

            confiner.m_BoundingShape2D = GameObject.FindWithTag("MapBorder").GetComponent<PolygonCollider2D>();
            
            cam.Follow = player;
        }
    }
}