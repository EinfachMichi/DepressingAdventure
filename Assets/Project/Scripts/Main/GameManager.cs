using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Main
{
    public class GameManager : Singleton<GameManager>
    {
        public SaveData data;
        
        protected override void Awake()
        {
            base.Awake();
            SaveSystem.Load(out SaveData data);
            if(data.FirstLoaded) FirstLoad();
            else
            {
                this.data = data;
                if (data.LastSceneInfo == null) return;
                
                if(!data.LastSceneLoaded)
                {
                    data.LastSceneLoaded = true;
                    Save();
                    SceneManager.LoadScene(data.LastSceneInfo.name);
                }
            }
        }

        private void FirstLoad()
        {
            SceneInfo tutorial = new SceneInfo();
            tutorial.name = "Tutorial";
            data.SceneInfos[0] = tutorial;

            SceneInfo village = new SceneInfo();
            village.name = "Village";
            data.SceneInfos[1] = village;

            SceneInfo forest = new SceneInfo();
            forest.name = "Forest";
            data.SceneInfos[2] = forest;
                
            data.FirstLoaded = false;
            Save();
        }
        
        public void Save()
        {
            SaveSystem.Save(data);
        }

        public void SaveSceneInfo(SceneInfo info)
        {
            for (int i = 0; i < data.SceneInfos.Length; i++)
            {
                if (info.name == data.SceneInfos[i].name)
                {
                    data.SceneInfos[i] = info;
                    break;
                }
            }
            Save();
        }

        public SceneInfo GetCurrentSceneInfo()
        {
            for (int i = 0; i < data.SceneInfos.Length; i++)
            { 
                if (SceneManager.GetActiveScene().name == data.SceneInfos[i].name)
                {
                    return data.SceneInfos[i];
                }
            }
            return new SceneInfo();
        }

        private void OnApplicationQuit()
        {
            SceneInfo info = GetCurrentSceneInfo();
            info.playerPos = GameObject.FindWithTag("Player").transform.position;
            data.LastSceneInfo = info;
            data.LastSceneLoaded = false;
            SaveSceneInfo(info);
        }
    }
}