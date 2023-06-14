using System;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Main
{
    public class SpawnHandler : MonoBehaviour
    {
        private Transform player;
        
        private void Awake()
        {
            player = FindObjectOfType<PlayerMovement>().transform;
        }

        private void Start()
        {
            if (SceneManager.GetActiveScene().name == "House") return;
            
            if (GameManager.Instance.GetCurrentSceneInfo().playerPos == Vector2.zero) return;

            switch (SceneManager.GetActiveScene().name)
            {
                case "Tutorial":
                    if (PlayerPrefs.GetString("LastScene") == "House")
                    {
                        player.position = GameManager.Instance.GetCurrentSceneInfo().playerPos;
                        break;
                    }

                    if (PlayerPrefs.GetString("LastScene") == "Forest")
                    {
                        player.position = GameManager.Instance.GetCurrentSceneInfo().playerPos + Vector2.up;
                        break;
                    }
                    player.position = GameManager.Instance.GetCurrentSceneInfo().playerPos + Vector2.right;
                    break;
                case "Village":
                    if (PlayerPrefs.GetString("LastScene") == "House")
                    {
                        player.position = GameManager.Instance.GetCurrentSceneInfo().playerPos;
                        break;
                    }
                    player.position = GameManager.Instance.GetCurrentSceneInfo().playerPos + Vector2.left;
                    break;
                case "Forest":
                    if (PlayerPrefs.GetString("LastScene") == "House")
                    {
                        player.position = GameManager.Instance.GetCurrentSceneInfo().playerPos;
                        break;
                    }
                    player.position = GameManager.Instance.GetCurrentSceneInfo().playerPos + Vector2.down;
                    break;
            }
            
        }
    }
}