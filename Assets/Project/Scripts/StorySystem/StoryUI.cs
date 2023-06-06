using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace StorySystem
{
    public class StoryUI : MonoBehaviour
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
            StoryManager.Instance.OnStoryBegin += OnDialogStart;
            StoryManager.Instance.OnStoryEnd += OnDialogEnd;
            StoryManager.Instance.OnTextChanged += OnTextChanged;
            StoryManager.Instance.OnSpeakerChanged += OnSpeakerChanged;
            StoryManager.Instance.OnChoice += OnChoice;
            StoryManager.Instance.OnChoiceOver += OnChoiceOver;
            
            Choices.SetActive(false);
        }

        private void OnDialogStart()
        {
            anim.SetTrigger("FadeIn");
        }

        private void OnSpeakerChanged(Speaker speaker)
        {
            SpeakerName.text = speaker.Name;
            IconImage.sprite = speaker.Portrait;
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