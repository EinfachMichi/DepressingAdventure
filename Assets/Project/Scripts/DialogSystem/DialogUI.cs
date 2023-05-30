using System;
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
            DialogManager.Instance.OnTextChanged += OnTextChanged;
            DialogManager.Instance.OnDialogEnd += OnDialogEnd;
        }

        private void OnDialogStart(Dialog dialog, int index)
        {
            anim.SetTrigger("FadeIn");
            
            IconImage.sprite = dialog.Speaker(index).Icon;
            SpeakerName.text = dialog.Speaker(index).Name;
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