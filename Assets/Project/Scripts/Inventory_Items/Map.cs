using Inventory_Items;
using Main;

public class Map : ItemObject
{
    public void OnPickup()
    {
        GameManager.Instance.Data.Barriers[0] = false;
        GameManager.Instance.Save();
    }
}
