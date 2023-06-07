using UnityEngine;

namespace DialogSystem
{
    [CreateAssetMenu(menuName = "Custom/Dialog/New Dialog")]
    public class Dialog : ScriptableObject
    {
        public Sentence[] Sentences;

        public string GetText(int index)
        {
            return Sentences[index].Text;
        }

        public bool CanReadNext(int index)
        {
            return index + 1 < Sentences.Length;
        }

        public Speaker GetSpeaker(int index)
        {
            return Sentences[index].Speaker;
        }

        public bool HasChoices(int index, out Choice choice)
        {
            choice = Sentences[index].Choice;
            return choice.Answers.Length != 0;
        }

        public Dialog GetDialogFromChoice(int index, int num)
        {
            return Sentences[index].Choice.Answers[num].Dialog;
        }
    }
}