using System;
using UnityEngine;

namespace DialogSystem
{
    [Serializable]
    public class Sentence
    {
        public Speaker Speaker;
        [TextArea(3, 5)] public string Line;
    }
}