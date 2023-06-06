using System;
using Cinemachine;
using Main;
using UnityEngine;

namespace Camera
{
    public class MainCamera : Singleton<MainCamera>
    {
        private CinemachineConfiner confiner;

        protected override void Awake()
        {
            base.Awake();
            confiner = GetComponent<CinemachineConfiner>();

            PolygonCollider2D col = GameObject.FindWithTag("StartBorder").GetComponent<PolygonCollider2D>();

            if(col) confiner.m_BoundingShape2D = col;
        }

        public void SetBorder(PolygonCollider2D collider)
        {
            confiner.m_BoundingShape2D = collider;
        }

        public Collider2D Border() => confiner.m_BoundingShape2D;
    }
}