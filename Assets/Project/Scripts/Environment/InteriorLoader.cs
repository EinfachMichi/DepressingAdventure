using System;
using UnityEngine;

namespace Environment
{
    public class InteriorLoader : MonoBehaviour
    {
        private House house;
        private Transform player;
        private Transform spawnpoint;
        
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

        private void Start()
        {
            player = GameObject.FindWithTag("Player").transform;
            spawnpoint = GameObject.FindWithTag("Spawnpoint").transform;

            Invoke("TPPlayer", 0.05f);
        }

        void TPPlayer()
        {
            player.position = spawnpoint.position;
        }
    }
}