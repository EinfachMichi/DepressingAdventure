using DialogSystem;
using Main;
using UnityEngine;

namespace Other
{
    public class NarratorDialog : Singleton<NarratorDialog>
    {
        public void SayNarratorLine(Dialog dialog, int sentenceIndex)
        {
            if (dialog.name == "Iris_Start")
            {
                if (sentenceIndex == 4)
                {
                    Pause(11);
                    return;
                }
                
                if (sentenceIndex == 6)
                {
                    Pause(12);
                    return;
                }
            }
            
            if (dialog.name == "Iris_Start_Choice_02")
            {
                if (sentenceIndex == 22)
                {
                    Pause(13);
                    return;
                }
            }
        }

        private void Pause(int id)
        {
            Narrator.Instance.MainPlay(id);
            DialogManager.Instance.Pause();
            Invoke("Unpause", Narrator.Instance.CurrentClip.length);
        }
        
        private void Unpause()
        {
            DialogManager.Instance.UnPause();
        }
    }
}