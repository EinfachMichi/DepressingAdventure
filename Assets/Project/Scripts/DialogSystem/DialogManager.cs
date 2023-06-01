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
        public event Action<string> OnPreCalculationResults;
        public event Action OnDialogStart;
        public event Action OnDialogEnd;

        public float CharactersPerSecond = 40;

        private TextAsset[] stories;
        private Dialog dialog;

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
            StartPassage(pid);
        }
        
        public void StartPassage(int pid)
        {
            dialog = JsonUtility.FromJson<Dialog>(stories[GameManager.Instance.CurrentRegion].text);
            Passage passage = dialog.GetPassage(pid);
            
            StartCoroutine(Type(passage));
        }

        private IEnumerator Type(Passage passage)
        {
            lineFinished = false;
            currentPassage = passage;
            
            bool knowSpeaker = false;
            
            string speaker = "";
            string text = "";

            for (int i = 0; i < passage.text.Length; i++)
            {
                if (!knowSpeaker)
                {
                    speaker += passage.text[i];
                    if (passage.text[i] == ':')
                    {
                        knowSpeaker = true;
                        continue;
                    }
                    OnSpeakerChanged?.Invoke(speaker);
                    continue;
                }

                if(passage.links.Count == 1) if(passage.text[i] == '[' || passage.text[i] == ']') break;
                if (passage.links.Count == 2) if(passage.text[i] == '[' || passage.text[i] == ']') continue;

                text += passage.text[i];
                OnTextChanged?.Invoke(text);
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
                StartPassage(currentPassage.links[0].pid);
            }
        }
    }
}
