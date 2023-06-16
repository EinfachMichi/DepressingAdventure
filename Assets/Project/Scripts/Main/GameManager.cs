using System;
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

            playerTransform = GameObject.FindWithTag("Player").transform;
            
            Data = JsonUtility.FromJson<SaveData>(PlayerPrefs.GetString(saveDataPath));
            if (Data == null)
            {
                Data = new SaveData();
                InitScenes();
                InitNPCs();
                Save();
            }
            
            if (!Data.FirstLoad)
            {
                Data.FirstLoad = true;
                Save();
                LoadLastScene();
            }
        }

        private void Start()
        {
            Vector2 offset = new Vector2();
            switch (SceneManager.GetActiveScene().name)
            {
                case "Tutorial":
                    if(Data.LastScene.Name == "Village") offset = Vector2.right;
                    else if(Data.LastScene.Name == "Forest") offset = Vector2.up;
                    break;
                case "Village":
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
            Data.SceneInfos = new SceneInfo[4];

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
        }
        
        private void InitNPCs()
        {
            Data.NpcInfos = new NPCInfo[2];

            NPCInfo harald = new NPCInfo();
            harald.Name = "Harald";
            Data.NpcInfos[0] = harald;
            
            NPCInfo iris = new NPCInfo();
            iris.Name = "Iris";
            Data.NpcInfos[1] = iris;
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
    }

    [Serializable]
    public class SaveData
    {
        public bool FirstLoad;
        public SceneInfo LastScene;
        public SceneInfo[] SceneInfos;
        public NPCInfo[] NpcInfos;
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