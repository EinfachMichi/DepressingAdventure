using System;
using UnityEngine;
using UnityEngine.Events;

namespace DialogSystem
{
    [Serializable]
    public struct Sentence
    {
        public Speaker Speaker;
        [TextArea(3, 5)] public string Text;
        public Choice Choice;
    }
}