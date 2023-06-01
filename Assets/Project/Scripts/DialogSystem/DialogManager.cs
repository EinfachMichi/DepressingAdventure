using System;
using System.Collections;
using Main;
using UnityEngine;

namespace DialogSystem
{
    public class DialogManager : Singleton<DialogManager>
    {
        public const int MaxCharacters = 80;
        
        public event Action<string> OnSpeakerChanged;
        public event Action<string> OnTextChanged;
        public event Action OnDialogStart;
        public event Action OnDialogEnd;

        public float CharactersPerSecond = 40;

        private TextAsset[] stories;
        private Dialog dialog;
        
        private Passage currentPassage;
        private bool lineFinished;
        private bool dialogFinished;

        private string passageText;
        private string passageSpeaker;
        private int textIndex;
        private int speakerLength;
        private bool knowSpeaker;
        private int sentenceLoop;

        protected override void Awake()
        {
            base.Awake();
            stories = Resources.LoadAll<TextAsset>("Dialogs");
        }

        private void Update()
        {
            if (!lineFinished) return;

            if (Input.GetKeyDown(KeyCode.F))
            {
                Next();
            }
        }
        
        
        public void StartDialog(int pid)
        {
            OnDialogStart?.Invoke();
            StartTyping(pid);
        }

        private void StartTyping(int pid)
        {
            CompilePassage(pid);
        }
        
        private void CompilePassage(int pid)
        {
            dialog = JsonUtility.FromJson<Dialog>(stories[GameManager.Instance.CurrentRegion].text);
            currentPassage = dialog.GetPassage(pid);

            if (sentenceLoop == 0)
            {
                passageSpeaker = "";
                while (currentPassage.text[speakerLength] != ':')
                {
                    passageSpeaker += currentPassage.text[speakerLength];
                    speakerLength++;
                }

                speakerLength += 2;
                textIndex += speakerLength;
            }
            OnSpeakerChanged?.Invoke(passageSpeaker);

            int index = textIndex;
            string text = "";
            while (index < MaxCharacters + textIndex)
            {
                if (currentPassage.text.Length <= index) break;

                if (currentPassage.links.Count == 1)
                {
                    if (currentPassage.text[index] == '[' || currentPassage.text[index] == ']')
                    {
                        break;
                    }
                }
                
                if (currentPassage.links.Count == 2)
                {
                    if (currentPassage.text[index] == '[' || currentPassage.text[index] == ']')
                    {
                        index++;
                        continue;
                    }
                }
                
                text += currentPassage.text[index];
                index++;
            }
            textIndex = index;

            if (text.Length >= MaxCharacters)
            {
                sentenceLoop++;
            }
            else
            {
                textIndex = 0;
                sentenceLoop = 0;
                speakerLength = 0;
            }

            StartCoroutine(Type(text));
        }

        private IEnumerator Type(string text)
        {
            lineFinished = false;

            string typedText = "";
            for (int i = 0; i < text.Length; i++)
            {
                typedText += text[i];
                OnTextChanged?.Invoke(typedText);
                yield return new WaitForSeconds(1 / CharactersPerSecond);
            }

            lineFinished = true;
        }

        private void Next()
        {
            if (currentPassage.links.Count == 0)
            {
                OnDialogEnd?.Invoke();
                dialogFinished = true;
                return;
            }

            if (currentPassage.links.Count == 1)
            {
                if(sentenceLoop > 0)
                {
                    StartTyping(currentPassage.pid);
                }
                else
                {
                    StartTyping(currentPassage.links[0].pid);
                }
            }
        }
    }
}