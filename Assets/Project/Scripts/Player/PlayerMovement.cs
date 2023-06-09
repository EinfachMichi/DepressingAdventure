﻿using System;
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
        private Vector2 dir;
        private bool inTp;
        
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
            
            if (state == GameState.InTeleportation)
            {
                inTp = true;
                rb.velocity = dir * speed;
                anim.SetFloat("Speed", 0f);
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
            if (inTp) return;
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
                if (rb.velocity == Vector2.zero)
                {
                    AudioManager.Instance.Play("Walk", AudioManager.AudioSound.EffectSounds);
                }
                moveVector = context.ReadValue<Vector2>();
                dir = moveVector;
            }
            else if (context.canceled && GameStateManager.Instance.GameState != GameState.InTeleportation)
            {
                moveVector = Vector2.zero;
                AudioManager.Instance.StopAllSounds(AudioManager.AudioSound.EffectSounds);
            }
        }
        public void Run(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                if (rb.velocity != Vector2.zero)
                {
                    AudioManager.Instance.Play("Run", AudioManager.AudioSound.EffectSounds);
                    AudioManager.Instance.Stop("Walk", AudioManager.AudioSound.EffectSounds);
                    anim.SetBool("Run", true);
                }
                speed = RunSpeed;
            }
            else if (context.canceled)
            {
                if (rb.velocity != Vector2.zero)
                {
                    AudioManager.Instance.Stop("Run", AudioManager.AudioSound.EffectSounds);
                    AudioManager.Instance.Play("Walk", AudioManager.AudioSound.EffectSounds);
                }
                anim.SetBool("Run", false);
                speed = WalkSpeed;
            }
        }
    }
}