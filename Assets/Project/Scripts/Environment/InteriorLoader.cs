using UnityEngine;

namespace Environment
{
    public class InteriorLoader : MonoBehaviour
    {
        private House house;
        
        private void Awake()
        {
            House[] houses = Resources.LoadAll<House>("Prefabs/LevelDesign/Interiors");
            foreach (House house in houses)
            {
                if (house.HouseID == PlayerPrefs.GetString("HouseID"))
                {
                    this.house = house;
                    break;
                }
            }

            Instantiate(house);
        }
    }
}