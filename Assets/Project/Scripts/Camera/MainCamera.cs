using Cinemachine;
using Main;
using UnityEngine;

namespace Camera
{
    public class MainCamera : Singleton<MainCamera>
    {
        public PolygonCollider2D startBoundary;
        
        private CinemachineConfiner confiner;

        protected override void Awake()
        {
            base.Awake();
            confiner = GetComponent<CinemachineConfiner>();
            confiner.m_BoundingShape2D = startBoundary;
        }

        public void SetBoundary(PolygonCollider2D collider)
        {
            confiner.m_BoundingShape2D = collider;
        }
    }
}