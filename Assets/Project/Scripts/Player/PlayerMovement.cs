using System;
using Environment;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        public float WalkSpeed;
        public float RunSpeed;
    
        private Rigidbody2D rb;
        private bool canMove = true;
        private float speed;
        private Vector2 movementInput;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            TeleportAnimation.Instance.OnTeleportAnimationStart += Freeze;
            TeleportAnimation.Instance.OnTeleportAnimationDone += UnFreeze;

            speed = WalkSpeed;
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            if (!canMove)
            {
                rb.velocity = Vector2.zero;
                return;
            }

            movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            speed = Input.GetKey(KeyCode.LeftShift) ? RunSpeed : WalkSpeed;

            rb.velocity = speed * movementInput.normalized;
        }

        public void Freeze() => canMove = false;
        public void UnFreeze() => canMove = true;
    }
}