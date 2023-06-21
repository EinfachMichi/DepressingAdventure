using System;
using Main;
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

            Narrator.Instance.MainPlay(4);

            if (house.HouseID == "warehouse" && GameManager.Instance.Data.NpcInfos[2].DialogIndex == 1)
            {
                Narrator.Instance.MainPlay(25);
            }

            if (house.HouseID == "hexenhaus" && GameManager.Instance.Data.Played(45))
            {
                Narrator.Instance.MainPlay(46);
            }
            
            Invoke("TPPlayer", 0.05f);
        }

        void TPPlayer()
        {
            player.position = spawnpoint.position;
        }
    }
}