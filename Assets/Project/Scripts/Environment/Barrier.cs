using UnityEngine;

namespace Environment
{
    public class Barrier : MonoBehaviour
    {
        public GameObject gameObj;
        
        public void Disable() => gameObj.SetActive(false);
        public void Enable() => gameObj.SetActive(true);
    }
}