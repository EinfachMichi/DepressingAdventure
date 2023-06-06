namespace Main
{
    public interface IInteractable
    {
        public bool interactable { get; set; }
        
        public void ShowInteraction();
        public void Interaction();
    }
}