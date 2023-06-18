using System;
using Inventory_Items;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Main
{
    public class GameManager : Singleton<GameManager>
    {
        private const string saveDataPath = "SaveData";

        public bool Delete;
        public SaveData Data;

        private Transform playerTransform;

        protected override void Awake()
        {
            base.Awake();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            playerTransform = GameObject.FindWithTag("Player").transform;
            
            Data = JsonUtility.FromJson<SaveData>(PlayerPrefs.GetString(saveDataPath));
            if (Data == null)
            {
                Data = new SaveData();
                InitScenes();
                InitNPCs();
                InitBarriers();
                InitInventory();
                InitItems();
                Save();
            }
            
            if (!Data.FirstLoad)
            {
                Data.FirstLoad = true;
                Save();
                LoadLastScene();
            }
        }

        private void StartNarr()
        {
            Narrator.Instance.MainPlay(1);
            Invoke("StartHouseReminder", Narrator.Instance.CurrentClip.length);
        }

        private void StartHouseReminder()
        {
            Invoke("HouseReminder", 7.5f);
        }
        
        private void HouseReminder()
        {
            Narrator.Instance.MainPlay(3);
        }
        
        private void Start()
        {
            if(!Data.FirstSpawn)
            {
                Data.FirstSpawn = true;
                Narrator.Instance.MainPlay(0);
                Invoke("StartNarr", Narrator.Instance.CurrentClip.length + 1f);
                Save();
                return;
            }

            if (SceneManager.GetActiveScene().name == "Village")
            {
                Narrator.Instance.MainPlay(15);
            }
            
            Vector2 offset = new Vector2();
            if (Data.LastScene == null) return;
            switch (SceneManager.GetActiveScene().name)
            {
                case "Tutorial":
                    if(Data.LastScene.Name == "Village") offset = Vector2.right;
                    else if(Data.LastScene.Name == "Forest") offset = Vector2.up;
                    else if(Data.LastScene.Name == "WitchVillage") offset = Vector2.right;
                    break;
                case "Village":
                    if(Data.LastScene.Name == "Tutorial") offset = Vector2.left;
                    break;
                case "WitchVillage":
                    if(Data.LastScene.Name == "Tutorial") offset = Vector2.left;
                    break;
                case "Forest":
                    if(Data.LastScene.Name == "Tutorial") offset = Vector2.down;
                    break;
            }
            playerTransform.position = GetCurrentSceneInfo().PlayerPosition + offset;
        }

        private void LoadLastScene()
        {
            if (Data.LastScene != null)
            {
                if (Data.LastScene.Name == SceneManager.GetActiveScene().name) return;
                
                SceneManager.LoadScene(Data.LastScene.Name);
            }
        }

        public void Save()
        {
            PlayerPrefs.SetString(saveDataPath, JsonUtility.ToJson(Data));
            PlayerPrefs.Save();
        }

        public void SaveCurrentSceneInfo()
        {
            for (int i = 0; i < Data.SceneInfos.Length; i++)
            {
                if (Data.SceneInfos[i].Name == SceneManager.GetActiveScene().name)
                {
                    SceneInfo info = new SceneInfo();
                    info.Name = SceneManager.GetActiveScene().name;
                    info.PlayerPosition = playerTransform.position;
                    Data.SceneInfos[i] = info;
                    break;
                }
            }
            Save();
        }

        public void SaveLastSceneInfo()
        {
            Data.LastScene = GetCurrentSceneInfo();
        }

        private void InitScenes()
        {
            Data.SceneInfos = new SceneInfo[5];

            SceneInfo tutorial = new SceneInfo();
            tutorial.Name = "Tutorial";
            Data.SceneInfos[0] = tutorial;
            
            SceneInfo village = new SceneInfo();
            village.Name = "Village";
            Data.SceneInfos[1] = village;
            
            SceneInfo forest = new SceneInfo();
            forest.Name = "Forest";
            Data.SceneInfos[2] = forest;
            
            SceneInfo house = new SceneInfo();
            house.Name = "House";
            Data.SceneInfos[3] = house;
            
            SceneInfo witchVillage = new SceneInfo();
            witchVillage.Name = "WitchVillage";
            Data.SceneInfos[4] = witchVillage;
        }
        
        private void InitNPCs()
        {
            Data.NpcInfos = new NPCInfo[6];

            NPCInfo harald = new NPCInfo();
            harald.Name = "Harald";
            Data.NpcInfos[0] = harald;
            
            NPCInfo iris = new NPCInfo();
            iris.Name = "Iris";
            Data.NpcInfos[1] = iris;
            
            NPCInfo fronicka = new NPCInfo();
            fronicka.Name = "Fronicka";
            Data.NpcInfos[2] = fronicka;
            
            NPCInfo ludmilla = new NPCInfo();
            ludmilla.Name = "Ludmilla";
            Data.NpcInfos[3] = ludmilla;
            
            NPCInfo nikolaus = new NPCInfo();
            nikolaus.Name = "Nikolaus";
            Data.NpcInfos[4] = nikolaus;
            
            NPCInfo elisabeth = new NPCInfo();
            elisabeth.Name = "Elisabeth";
            Data.NpcInfos[5] = elisabeth;
        }

        private void InitBarriers()
        {
            Data.Barriers = new [] {true, true, true, true, true};
        }

        private void InitInventory()
        {
            Data.InventoryInfo = new InventoryInfo();
            Data.InventoryInfo.ItemIDs = new int[5];
        }

        private void InitItems()
        {
            Data.ItemInfos = new ItemInfo[10];
        }

        private SceneInfo GetCurrentSceneInfo()
        {
            for (int i = 0; i < Data.SceneInfos.Length; i++)
            {
                if (Data.SceneInfos[i].Name == SceneManager.GetActiveScene().name)
                {
                    return Data.SceneInfos[i];
                }
            }
            return null;
        }
        
        private void OnApplicationQuit()
        {
            if (Delete)
            {
                PlayerPrefs.DeleteAll();
                return;
            }
            
            SceneInfo info = new SceneInfo();
            info.Name = SceneManager.GetActiveScene().name;
            info.PlayerPosition = playerTransform.position;
            Data.FirstLoad = false;
            Data.LastScene = info;
            SaveCurrentSceneInfo();
            Save();
        }

        public bool GetNPCInfo(string name, out NPCInfo info)
        {
            for (int i = 0; i < Data.NpcInfos.Length; i++)
            {
                if (name == Data.NpcInfos[i].Name)
                {
                    info = Data.NpcInfos[i];
                    return true;
                }
            }
            info = null;
            return false;
        }

        public void SaveItemInfo(ItemInfo info)
        {
            for (int i = 0; i < Data.ItemInfos.Length; i++)
            {
                if (Data.ItemInfos[i].ItemID == info.ItemID || Data.ItemInfos[i].ItemID == 0)
                {
                    Data.ItemInfos[i].ItemID = info.ItemID;
                    Data.ItemInfos[i].Active = info.Active;
                }
            }
        }
        
        public void SaveInventory(Slot[] slots)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                Data.InventoryInfo.ItemIDs[i] = slots[i].GetItemID();
            }
        }
    }

    [Serializable]
    public class SaveData
    {
        public bool FirstLoad;
        public bool FirstSpawn;
        public SceneInfo LastScene;
        public SceneInfo[] SceneInfos;
        public NPCInfo[] NpcInfos;
        public bool[] Barriers;
        public InventoryInfo InventoryInfo;
        public ItemInfo[] ItemInfos;
        public bool WitchVillage;
        public bool LudmillaDead;
        public bool CanCollectRose;
        public NarratorInfo[] NarratorInfos;
        public bool NarratorLoaded;
        public bool BrotPlaced;
        public bool HaraldCanTriggerNarrator;
        
        public bool Played(int ID)
        {
            foreach (NarratorInfo info in NarratorInfos)
            {
                if (info.ID == ID)
                {
                    return info.Played;
                }
            }
            return false;
        }

        public void SetPlayed(int ID)
        {
            foreach (NarratorInfo info in NarratorInfos)
            {
                if (info.ID == ID)
                {
                    info.Played = true;
                    break;
                }
            }
        }
    }

    [Serializable]
    public class NarratorInfo
    {
        public int ID;
        public bool Played;
    }
    
    [Serializable]
    public class ItemInfo
    {
        public int ItemID;
        public bool Active = true;
    }

    [Serializable]
    public class InventoryInfo
    {
        public int[] ItemIDs;
    }
    
    [Serializable]
    public class SceneInfo
    {
        public string Name;
        public Vector2 PlayerPosition;
    }

    [Serializable]
    public class NPCInfo
    {
        public string Name;
        public int DialogIndex;
    }
}