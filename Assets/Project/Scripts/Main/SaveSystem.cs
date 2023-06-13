using System;
using System.IO;
using System.Xml.Serialization;
using InventorySystem;
using UnityEngine;

namespace Main
{
    public static class SaveSystem
    {
        public static string Path = Application.persistentDataPath + "/DASaveData.save";
        
        public static void Save(SaveData data)
        {
            var serializer = new XmlSerializer(typeof(SaveData));
            var stream = new FileStream(Path, FileMode.Create);
            serializer.Serialize(stream, data);
            stream.Close();
        }

        public static void Load(out SaveData data)
        {
            if (File.Exists(Path))
            {
                var serializer = new XmlSerializer(typeof(SaveData));
                var stream = new FileStream(Path, FileMode.Open);
                data = serializer.Deserialize(stream) as SaveData;
                stream.Close();
            }
            else
            {
                data = new SaveData();
                Save(data);
            }
        }
    }

    [Serializable]
    public class SaveData
    {
        public NPCData[] NpcDatas;
        public PlayerData PlayerData;
    }

    [Serializable]
    public class NPCData
    {
                
    }

    [Serializable]
    public class PlayerData
    {
        public Vector2 Position;
        public Inventory Inventory;
    }
}
