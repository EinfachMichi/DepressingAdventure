using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DialogSystem
{
    public class DialogUI : MonoBehaviour
    {
        // Main
        public Image IconImage;
        public TextMeshProUGUI SpeakerName;
        public TextMeshProUGUI Line;
        
        // Choices
        public GameObject Choices;
        public TextMeshProUGUI Choice1Text;
        public TextMeshProUGUI Choice2Text;
        
        // Animations
        public Animator anim;
        
        private void Start()
        {
            DialogManager.Instance.OnDialogStart += OnDialogStart;
            DialogManager.Instance.OnDialogEnd += OnDialogEnd;
            DialogManager.Instance.OnTextChanged += OnTextChanged;
            DialogManager.Instance.OnSpeakerChanged += OnSpeakerChanged;
            DialogManager.Instance.OnChoice += OnChoice;
            DialogManager.Instance.OnChoiceOver += OnChoiceOver;
            
            Choices.SetActive(false);
        }

        private void OnDialogStart()
        {
            anim.SetTrigger("FadeIn");
        }

        private void OnSpeakerChanged(string speaker)
        {
            SpeakerName.text = speaker;
        }
        
        private void OnTextChanged(string text)
        {
            Line.text = text;
        }

        private void OnDialogEnd()
        {
            anim.SetTrigger("FadeOut");
        }

        private void OnChoice(string c1, string c2)
        {
            Choices.SetActive(true);
            Choice1Text.text = c1;
            Choice2Text.text = c2;
        }

        private void OnChoiceOver()
        {
            Choices.SetActive(false);
        }
    }
}