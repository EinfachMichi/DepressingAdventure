using System;
using UnityEngine;

namespace DialogSystem
{
    [Serializable]
    public struct Choice
    {
        public Answer[] Answers;
    }

    [Serializable]
    public struct Answer
    {
        [TextArea(3, 5)] public string Text;
        public Dialog Dialog;
    }
}