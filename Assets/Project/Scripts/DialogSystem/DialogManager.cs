using System;
using System.Collections;
using Main;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DialogSystem
{
    public class DialogManager : Singleton<DialogManager>
    {
        public event Action OnDialogStart;
        public event Action OnDialogEnd;
        public event Action<string> OnTextChanged;
        public event Action<Speaker> OnSpeakerChanged;
        public event Action<Choice> OnChoice;
        public event Action OnChoiceOver;
        public event Action<int> OnChoiceResults;

        public float CharactersPerSecond = 150;

        private Dialog dialog;
        private Coroutine typing;
        private bool lineFinished;
        private int sentenceIndex;
        private bool hasChoosen = true;
        private bool inDialog = false;

        public void StartDialog(Dialog dialog)
        {
            this.dialog = dialog;
            sentenceIndex = 0;
            inDialog = true;
            GameStateManager.Instance.ChangeGameState(GameState.InDialog);
            OnDialogStart?.Invoke();
            typing = StartCoroutine(Type());
        }

        private IEnumerator Type()
        {
            lineFinished = false;

            Speaker speaker = dialog.GetSpeaker(sentenceIndex);
            OnSpeakerChanged?.Invoke(speaker);
            
            string result = "";
            string text = dialog.GetText(sentenceIndex);
            for (int i = 0; i < text.Length; i++)
            {
                result += text[i];
                OnTextChanged?.Invoke(result);
                yield return new WaitForSeconds(1 / CharactersPerSecond);
            }

            lineFinished = true;
        }

        /*
         * These methods are called by an UnityEvent from the new InputSystem
         */
        
        public void Choose1(InputAction.CallbackContext context)
        {
            if (context.started && !hasChoosen)
            {
                dialog = dialog.GetDialogFromChoice(sentenceIndex, 0);
                OnChoiceResults?.Invoke(1);
                UpdateChoose();
            }
        }

        public void Choose2(InputAction.CallbackContext context)
        {
            if (context.started && !hasChoosen)
            {
                dialog = dialog.GetDialogFromChoice(sentenceIndex, 1);
                OnChoiceResults?.Invoke(2);
                UpdateChoose();
            }
        }
        
        private void UpdateChoose()
        {
            sentenceIndex = 0;
            hasChoosen = true;
            OnChoiceOver?.Invoke();
            if (dialog == null)
            {
                inDialog = false;
                GameStateManager.Instance.ChangeGameState(GameState.Playing);
                OnDialogEnd?.Invoke();
                return;
            }
            typing = StartCoroutine(Type());
        }
        
        public void NextSentence(InputAction.CallbackContext context)
        {
            if (!inDialog) return;
            
            if (context.started && lineFinished && hasChoosen)
            {
                if (dialog.HasChoices(sentenceIndex, out Choice choice))
                {
                    hasChoosen = false;
                    OnChoice?.Invoke(choice);
                }
                else if(dialog.CanReadNext(sentenceIndex))
                {
                    sentenceIndex++;
                    typing = StartCoroutine(Type());
                }
                else
                {
                    inDialog = false;
                    GameStateManager.Instance.ChangeGameState(GameState.Playing);
                    OnDialogEnd?.Invoke();
                }
            }
        }
    }
}