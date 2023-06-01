using System;
using System.Collections;
using Main;
using UnityEngine;

namespace DialogSystem
{
    public class DialogManager : Singleton<DialogManager>
    {
        public event Action<string> OnSpeakerChanged;
        public event Action<string> OnTextChanged;
        public event Action<string> OnCompilingEnd;
        public event Action OnDialogStart;
        public event Action OnDialogEnd;

        public float CharactersPerSecond = 40;

        private TextAsset[] stories;
        private Dialog dialog;

        [HideInInspector] public bool compileDone;
        private Passage currentPassage;
        private bool lineFinished;
        private bool dialogFinished;

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
            StartCoroutine(CompilePassage(pid));
        }
        
        private IEnumerator CompilePassage(int pid)
        {
            dialog = JsonUtility.FromJson<Dialog>(stories[GameManager.Instance.CurrentRegion].text);
            currentPassage = dialog.GetPassage(pid);
            compileDone = false;
            
            bool knowSpeaker = false;
            string speaker = "";
            string text = "";            
            for (int i = 0; i < currentPassage.text.Length; i++)
            {
                if (!knowSpeaker)
                {
                    if (currentPassage.text[i] == ':')
                    {
                        knowSpeaker = true;
                        continue;
                    }
                    speaker += currentPassage.text[i];
                }

                if(currentPassage.links.Count == 1) 
                    if(currentPassage.text[i] == '[' || currentPassage.text[i] == ']') 
                        break;
                if (currentPassage.links.Count == 2) 
                    if(currentPassage.text[i] == '[' || currentPassage.text[i] == ']') 
                        continue;

                text += currentPassage.text[i];
            }

            lineFinished = true;
            OnSpeakerChanged?.Invoke(speaker);
            OnCompilingEnd?.Invoke(text);
            yield return new WaitUntil(() => compileDone);
            
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
                StartDialog(currentPassage.links[0].pid);
            }
        }
    }
}