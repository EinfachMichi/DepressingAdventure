using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DialogSystem
{
    public class DialogUI : MonoBehaviour
    {
        public Image IconImage;
        public TextMeshProUGUI SpeakerName;
        public TextMeshProUGUI Line;
        public Animator anim;
        

        private void Start()
        {
            DialogManager.Instance.OnDialogStart += OnDialogStart;
            DialogManager.Instance.OnDialogEnd += OnDialogEnd;
            DialogManager.Instance.OnTextChanged += OnTextChanged;
            DialogManager.Instance.OnSpeakerChanged += OnSpeakerChanged;
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
    }
}