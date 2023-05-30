using System;
using System.Collections;
using Main;
using UnityEngine;

namespace DialogSystem
{
    public class DialogManager : Singleton<DialogManager>
    {
        public event Action<string> OnTextChanged;
        public event Action<Dialog, int> OnDialogStart; 
        public event Action OnDialogEnd; 
        
        public float CharactersPerSecond;

        private float charsPerSec;
        private Dialog dialog;
        private int sentenceIndex;
        private bool lineFinished;
        private bool dialogFinished;
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
            this.dialog = dialog;
            sentenceIndex = 0;
            lineFinished = false;
            dialogFinished = false;
            isClosed = false;
            OnDialogStart?.Invoke(dialog, sentenceIndex);

            StartCoroutine(Type());
        }

        private IEnumerator Type()
        {
            string text = dialog.Text(sentenceIndex);
            string sentence = "";
            lineFinished = false;
            for (int i = 0; i < text.Length; i++)
            {
                sentence += text[i];
                OnTextChanged?.Invoke(sentence);
                yield return new WaitForSeconds(1 / charsPerSec);
            }

            lineFinished = true;
            if (dialog.Sentences.Length <= sentenceIndex + 1)
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

            sentenceIndex++;
            StartCoroutine(Type());
        }
    }
}