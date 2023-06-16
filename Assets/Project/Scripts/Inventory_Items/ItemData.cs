using UnityEngine;

namespace Inventory_Items
{
    [CreateAssetMenu(menuName = "Custom/New Item")]
    public class ItemData : ScriptableObject
    {
        public string Name;
        public Sprite Icon;
        public int ID;
    }
}