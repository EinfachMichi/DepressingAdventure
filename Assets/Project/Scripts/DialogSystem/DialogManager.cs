using System;
using System.Collections;
using Main;
using UnityEngine;
using UnityEngine.Serialization;

namespace DialogSystem
{
    public class DialogManager : Singleton<DialogManager>
    {
        public event Action<string> OnTextChanged;
        public event Action OnDialogStart; 
        public event Action OnDialogEnd; 
        
        public float CharactersPerSecond;

        private float charsPerSec;
        public Dialog Dialog;
        public int SentenceIndex;
        private bool lineFinished;
        private bool dialogFinished = true;
        private bool isClosed;

        private void Start()
        {
            charsPerSec = CharactersPerSecond;
        }

        private void Update()
        {
            if (Input.GetMouseButton(0)) charsPerSec = CharactersPerSecond * 2;
            else charsPerSec = CharactersPerSecond;
            
            if(Input.GetKeyDown(KeyCode.Return) && lineFinished && !isClosed) NextLine();
        }

        public void StartDialog(Dialog dialog)
        {
            if (!dialogFinished) return;
            
            this.Dialog = dialog;
            SentenceIndex = 0;
            lineFinished = false;
            dialogFinished = false;
            isClosed = false;
            OnDialogStart?.Invoke();

            StartCoroutine(Type());
        }

        private IEnumerator Type()
        {
            string text = Dialog.Text(SentenceIndex);
            string sentence = "";
            lineFinished = false;
            for (int i = 0; i < text.Length; i++)
            {
                sentence += text[i];
                OnTextChanged?.Invoke(sentence);
                yield return new WaitForSeconds(1 / charsPerSec);
            }

            lineFinished = true;
            if (Dialog.Sentences.Length <= SentenceIndex + 1)
            {
                dialogFinished = true;
            }
        }

        private void NextLine()
        {
            if (dialogFinished)
            {
                OnDialogEnd?.Invoke();
                isClosed = true;
                return;
            }

            SentenceIndex++;
            StartCoroutine(Type());
        }
    }
}