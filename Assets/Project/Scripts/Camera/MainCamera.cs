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
            confiner.m_BoundingShape2D = GameObject.FindWithTag("StartBorder").GetComponent<PolygonCollider2D>();
        }

        public void SetBorder(PolygonCollider2D collider)
        {
            confiner.m_BoundingShape2D = collider;
        }

        public Collider2D Border() => confiner.m_BoundingShape2D;
    }
}