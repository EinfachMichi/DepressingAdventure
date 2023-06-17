using Inventory_Items;
using Main;

public class Rose : ItemObject
{
    protected override void Start()
    {
        base.Start();
        Invoke("LateStart", 0.05f);
    }

    private void LateStart()
    {
        interactable = GameManager.Instance.Data.CanCollectRose;
    }
}
