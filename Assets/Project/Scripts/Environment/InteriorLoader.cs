using UnityEngine;

namespace Environment
{
    public class InteriorLoader : MonoBehaviour
    {
        private House house;
        
        private void Awake()
        {
            House[] houses = Resources.LoadAll<House>("Prefabs/LevelDesign/Interiors");
            string id = PlayerPrefs.GetString("HouseID");
            foreach (House house in houses)
            {
                if (house.HouseID == id)
                {
                    this.house = house;
                    break;
                }
            }

            Instantiate(house);
        }
    }
}