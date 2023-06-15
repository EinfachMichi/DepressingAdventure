using System;
using Main;
using UnityEngine;

namespace Environment
{
    public class Teleporter : MonoBehaviour
    {
        public string SceneName;
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                SceneHandler.Instance.EnterNewScene(SceneName);
            }
        }
    }
}