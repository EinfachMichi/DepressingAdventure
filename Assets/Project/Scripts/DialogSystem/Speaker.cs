using UnityEngine;

namespace DialogSystem
{
    [CreateAssetMenu(menuName = "Dialog/New Speaker")]
    public class Speaker : ScriptableObject
    {
        public Sprite Icon;
        public string Name;
    }
}