using DialogSystem;
using Main;
using UnityEngine;

namespace Other
{
    public class NarratorDialog : Singleton<NarratorDialog>
    {
        public void SayNarratorLine(Dialog dialog, int sentenceIndex)
        {
            if (dialog.name == "Harald_Start")
            {
                if (sentenceIndex == 5)
                {
                    Pause(8);
                    return;
                }
            }
            
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

            if (dialog.name == "Iris_Retry")
            {
                if (sentenceIndex == 1 && !GameManager.Instance.Data.Played(16))
                {
                    Pause(16);
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