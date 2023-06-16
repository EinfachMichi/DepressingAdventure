using System;
using Main;
using UnityEngine;
using UnityEngine.Events;

namespace Environment
{
    public class House : MonoBehaviour
    {
        public string HouseID;

        private InteractableObject door;

        private void Awake()
        {
            door = GetComponentInChildren<InteractableObject>();
        }

        public void OnEnterHouse()
        {
            door.interactable = false;
            PlayerPrefs.SetString("HouseID", HouseID);
            SceneHandler.Instance.EnterNewScene("House");
        }

        public void OnExitHouse()
        {
            door.interactable = false;
            string sceneName = PlayerPrefs.GetString("LastScene");
            SceneHandler.Instance.EnterNewScene(sceneName);
        }
    }
}