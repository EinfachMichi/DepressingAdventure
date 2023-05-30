using UnityEngine;

namespace Environment
{
    public class HouseInfo : MonoBehaviour
    {
        public Transform TeleportationPoint;
        [HideInInspector] public PolygonCollider2D Collider;

        private void Awake()
        {
            Collider = GetComponentInChildren<PolygonCollider2D>();
        }
    }
}