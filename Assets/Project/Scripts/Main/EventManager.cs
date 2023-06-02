using UnityEngine;
using UnityEngine.SceneManagement;

namespace Main
{
    public class EventManager : MonoBehaviour
    {
        public void DisableGameobject(GameObject gameObject) => gameObject.SetActive(false);
        public void EnableGameobject(GameObject gameObject) => gameObject.SetActive(true);
        public void LoadScene(string sceneName) => SceneManager.LoadScene(sceneName);
    }
}