using DialogSystem;
using Inventory_Items;
using Main;

public class Rose : ItemObject
{
    public Dialog dialog;
    
    protected override void Start()
    {
        base.Start();
        Invoke("LateStart", 0.05f);
    }

    public override void Interaction()
    {
        base.Interaction();
        DialogManager.Instance.StartDialog(dialog);
    }

    private void LateStart()
    {
        interactable = GameManager.Instance.Data.CanCollectRose;
    }
}