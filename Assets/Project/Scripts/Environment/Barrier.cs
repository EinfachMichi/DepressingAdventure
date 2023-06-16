using System;
using DialogSystem;
using Main;
using UnityEngine;

namespace Environment
{
    public class Barrier : MonoBehaviour
    {
        public int ID;
        public bool Active;
        public Dialog dialog;
        public Vector2 pushDirection;

        private Transform player;
        
        private void Start()
        {
            Active = GameManager.Instance.Data.Barriers[ID];
            if (Active)
            {
                gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                player = col.gameObject.transform;
                DialogManager.Instance.OnDialogEnd += OnDialogEnd;
                DialogManager.Instance.StartDialog(dialog);
            }
        }

        public void Disable()
        {
            gameObject.SetActive(false);
            Active = false;
            GameManager.Instance.Data.Barriers[ID] = false;
        }
        
        private void OnDialogEnd()
        {
            DialogManager.Instance.OnDialogEnd -= OnDialogEnd;
            player.position += (Vector3) pushDirection;
        }
    }
}