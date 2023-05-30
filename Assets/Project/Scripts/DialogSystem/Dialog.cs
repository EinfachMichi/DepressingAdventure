using UnityEngine;

namespace DialogSystem
{
    [CreateAssetMenu(menuName = "Dialog/New Dialog")]
    public class Dialog : ScriptableObject
    {
        public Sentence[] Sentences;

        public string Text(int index)
        {
            return Sentences[index].Line;
        }

        public Speaker Speaker(int index)
        {
            return Sentences[index].Speaker;
        }
    }
}