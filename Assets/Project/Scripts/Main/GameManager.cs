using System;
using UnityEngine;

namespace Main
{
    public class GameManager : Singleton<GameManager>
    {
        private Region region = Region.Village;

        public int CurrentRegion => (int) region;
    }

    public enum Region
    {
        Village = 0,
        Forest = 1
    }
}