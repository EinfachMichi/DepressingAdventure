using DialogSystem;
using Main;

namespace AI
{
    public abstract class NPC : InteractableObject
    {
        public string Name;
        public Dialog[] Dialogs;
        protected NPCInfo info;

        protected int DialogIndex
        {
            get => info.DialogIndex;
            set => info.DialogIndex = value;
        }

        protected virtual void Start()
        {
            base.Start();
            if (GameManager.Instance.GetNPCInfo(Name, out NPCInfo info))
            {
                this.info = info;
            }
        }

        protected void ResetInteractable() => interactable = true;
    }
}