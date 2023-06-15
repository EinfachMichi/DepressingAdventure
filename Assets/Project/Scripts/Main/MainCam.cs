using System;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Main
{
    public class MainCam : MonoBehaviour
    {
        private CinemachineConfiner confiner;
        private CinemachineVirtualCamera cam;
        private Transform player;

        private void Start()
        {
            cam = GetComponentInChildren<CinemachineVirtualCamera>();
            confiner = GetComponentInChildren<CinemachineConfiner>();
            player = GameObject.FindWithTag("Player").transform;

            if (SceneManager.GetActiveScene().name == "House")
            {
                confiner.m_BoundingShape2D = GameObject.FindWithTag("HouseBorder").GetComponent<PolygonCollider2D>();
            }
            else
            {
                confiner.m_BoundingShape2D = GameObject.FindWithTag("MapBorder").GetComponent<PolygonCollider2D>();
            }
            
            cam.Follow = player;
        }
    }
}