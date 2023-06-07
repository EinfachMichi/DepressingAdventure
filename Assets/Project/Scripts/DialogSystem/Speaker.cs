using UnityEngine;

namespace DialogSystem
{
    [CreateAssetMenu(menuName = "Custom/Dialog/New Speaker")]
    public class Speaker : ScriptableObject
    {
        public string Name;
        public Sprite Icon;
    }
}