using UnityEngine;

namespace Player
{
    public abstract class Freezer : MonoBehaviour
    {
        protected bool isFreezed;
        
        public virtual void Freeze()
        {
            isFreezed = true;
        }

        public virtual void UnFreeze()
        {
            isFreezed = false;
        }
    }
}