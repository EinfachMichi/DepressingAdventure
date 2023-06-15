using System;
using Main;
using UnityEngine;
using UnityEngine.Events;

namespace Environment
{
    public class House : MonoBehaviour
    {
        public string HouseID;
        public UnityEvent startEvent;

        private InteractableObject door;

        private void Awake()
        {
            door = GetComponentInChildren<InteractableObject>();
        }

        private void Start()
        {
            startEvent.Invoke();
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

        public void DisableObject(GameObject gameObject)
        {
            gameObject.SetActive(false);
        }

        public void EnableObject(GameObject gameObject)
        {
            gameObject.SetActive(true);
        }
    }
}