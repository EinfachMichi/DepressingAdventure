using UnityEngine;

namespace DialogSystem
{
    [CreateAssetMenu(menuName = "Custom/New Speaker")]
    public class Speaker : ScriptableObject
    {
        public string Name;
        public Sprite Portrait;
    }
}