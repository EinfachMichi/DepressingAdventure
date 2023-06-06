using System;
using Environment;
using StorySystem;
using UnityEngine;
using UnityEngine.InputSystem;

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
        private Vector2 movementVector;

        #region Startup

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            TeleportAnimation.Instance.OnTeleportAnimationStart += Freeze;
            TeleportAnimation.Instance.OnTeleportAnimationDone += UnFreeze;
            StoryManager.Instance.OnStoryBegin += Freeze;
            StoryManager.Instance.OnStoryEnd += UnFreeze;

            speed = WalkSpeed;
        }

        #endregion

        private void FixedUpdate()
        {
            rb.velocity = speed * movementVector;
        }

        public void Move(InputAction.CallbackContext value)
        {
            if (!canMove)
            {
                movementVector = Vector2.zero;
                return;
            }

            movementVector = value.ReadValue<Vector2>();
        }

        public void Sprint(InputAction.CallbackContext value)
        {
            speed = value.performed ? RunSpeed : WalkSpeed;
        }

        public void Freeze() => canMove = false;
        public void UnFreeze() => canMove = true;
    }
}