using System;
using Main;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerMovement : Freezer
    {
        public float WalkSpeed;
        public float RunSpeed;

        private Rigidbody2D rb;
        private Animator anim;
        private Vector2 moveVector;
        private float speed;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponentInChildren<Animator>();

            speed = WalkSpeed;
        }

        private void Start()
        {
            GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
        }

        private void OnGameStateChanged(GameState state)
        {
            if(state == GameState.Playing)
            {
                UnFreeze();
                return;
            }
            
            Freeze();
        }

        public override void Freeze()
        {
            base.Freeze();
            moveVector = Vector2.zero;
        }

        private void OnDisable()
        {
            rb.velocity = Vector2.zero;
        }
        
        private void FixedUpdate()
        {
            SetVelocity();
            anim.SetFloat("Speed", rb.velocity.magnitude);
            if (moveVector != Vector2.zero)
            {
                anim.SetFloat("Horizontal", moveVector.x);
                anim.SetFloat("Vertical", moveVector.y);
            }
        }

        private void SetVelocity() => rb.velocity = speed * moveVector;

        /*
         * These methods are called by an UnityEvent from the new InputSystem
         */
        
        public void MoveInput(InputAction.CallbackContext context)
        {
            if (isFreezed) return;
            
            if (context.performed)
            {
                moveVector = context.ReadValue<Vector2>();
            }
            else if (context.canceled)
            {
                moveVector = Vector2.zero;
            }
        }
        public void Run(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                speed = RunSpeed;
            }
            else if (context.canceled)
            {
                speed = WalkSpeed;
            }
        }
    }
}