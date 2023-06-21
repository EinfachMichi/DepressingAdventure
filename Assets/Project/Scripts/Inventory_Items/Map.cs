using Inventory_Items;
using Main;

public class Map : ItemObject
{
    public void OnPickup()
    {
        GameManager.Instance.Data.Barriers[0] = false;
        Narrator.Instance.MainPlay(5);
        GameManager.Instance.Data.HaraldCanTriggerNarrator = true;
        GameManager.Instance.Save();
    }
}
