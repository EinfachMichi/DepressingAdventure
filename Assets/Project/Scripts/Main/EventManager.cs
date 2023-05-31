using UnityEngine;

namespace Main
{
    public class EventManager : MonoBehaviour
    {
        public void DisableGameobject(GameObject gameObject) => gameObject.SetActive(false);
        public void EnableGameobject(GameObject gameObject) => gameObject.SetActive(true);
    }
}