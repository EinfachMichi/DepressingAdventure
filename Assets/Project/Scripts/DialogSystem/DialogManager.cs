using System;
using System.Collections;
using Main;
using UnityEngine;

namespace DialogSystem
{
    public class DialogManager : Singleton<DialogManager>
    {
        public const int MaxCharacters = 100;
        
        public event Action<string> OnSpeakerChanged;
        public event Action<string> OnTextChanged;
        public event Action OnDialogStart;
        public event Action OnDialogEnd;

        public float CharactersPerSecond = 40;

        private TextAsset[] stories;
        private Dialog dialog;
        private Passage passage;

        private string speakerName;
        private bool finishedLine;

        protected override void Awake()
        {
            base.Awake();
            stories = Resources.LoadAll<TextAsset>("Dialogs");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F) && finishedLine)
            {
                NextPassage();
            }
        }

        public void StartDialog(int pid)
        {
            OnDialogStart?.Invoke();
            CompilePassage(pid);
        }

        private void CompilePassage(int pid)
        {
            finishedLine = false;
            
            // Get Data
            dialog = JsonUtility.FromJson<Dialog>(stories[GameManager.Instance.CurrentRegion].text);
            passage = dialog.GetPassage(pid);
            string text = passage.text;

            // Handle Speaker Name
            int charsToDelete = 0;
            speakerName = "";
            for (int i = 0; i < text.Length; i++)
            {
                charsToDelete++;
                if (text[i] == ':') break;
                speakerName += text[i];
            }
            text = text.Remove(0, charsToDelete + 1);
            OnSpeakerChanged?.Invoke(speakerName);
            
            /*
             * Handle Main Text
             */
            string result = "";
            
            // Case: 2 Links
            if (passage.links.Count == 2)
            {
                
            }
            
            // Case: 1 Link
            if (passage.links.Count == 1)
            {
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] == '[') break;
                    result += text[i];
                }
            }

            StartCoroutine(Write(result, passage.links.Count > 1));
        }

        private IEnumerator Write(string result, bool choices)
        {
            string text = "";
            if (!choices)
            {
                for (int i = 0; i < result.Length; i++)
                {
                    text += result[i];
                    OnTextChanged?.Invoke(text);
                    yield return new WaitForSeconds(1 / CharactersPerSecond);
                }
            }

            finishedLine = true;
        }

        private void NextPassage()
        {
            if (passage.links.Count == 1)
            {
                CompilePassage(passage.links[0].pid);
            }
        }
    }
}