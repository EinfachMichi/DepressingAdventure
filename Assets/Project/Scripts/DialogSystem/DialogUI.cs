using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DialogSystem
{
    public class DialogUI : MonoBehaviour
    {
        public GameObject DialogBox;
        public TextMeshProUGUI Text;
        public TextMeshProUGUI SpeakerName;
        public TextMeshProUGUI Answer1;
        public TextMeshProUGUI Answer2;
        public GameObject Choices;
        public Image SpeakerImage;

        private void Start()
        {
            DialogManager.Instance.OnTextChanged += OnTextChanged;
            DialogManager.Instance.OnSpeakerChanged += OnSpeakerChanged;
            DialogManager.Instance.OnChoice += OnChoice;
            DialogManager.Instance.OnChoiceOver += OnChoiceOver;
            DialogManager.Instance.OnDialogStart += OnDialogStart;
            DialogManager.Instance.OnDialogEnd += OnDialogEnd;
            
            DialogBox.SetActive(false);
            Choices.SetActive(false);
        }

        private void OnDialogStart()
        {
            DialogBox.SetActive(true);
        }

        private void OnDialogEnd()
        {
            DialogBox.SetActive(false);
        }
        
        private void OnTextChanged(string text)
        {
            Text.text = text;
        }

        private void OnSpeakerChanged(Speaker speaker)
        {
            SpeakerName.text = speaker.Name;
            SpeakerImage.sprite = speaker.Icon;
        }

        private void OnChoice(Choice chocie)
        {
            Choices.SetActive(true);
            Answer1.text = chocie.Answers[0].Text;
            Answer2.text = chocie.Answers[1].Text;
        }

        private void OnChoiceOver()
        {
            Choices.SetActive(false);
        }
    }
}