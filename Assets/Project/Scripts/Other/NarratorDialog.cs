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

            if (dialog.name == "01_Fronicka_FirstQuest")
            {
                if (sentenceIndex == 14)
                {
                    Pause(26);
                    return;
                }
            }

            if (dialog.name == "00_Ludmilla_Start")
            {
                if(sentenceIndex == 1)
                Pause(32);
                return;
            }

            if (dialog.name == "01_Ludmilla_Start_Choice_01")
            {
                if (sentenceIndex == 41)
                {
                    Pause(33);
                    return;
                }
            }

            if (dialog.name == "03_Ludmilla_Start_Choice_02_After")
            {
                if (sentenceIndex == 30)
                {
                    Pause(33);
                    return;
                }
            }

            if (dialog.name == "03_Ludmilla_Start_Choice_02_After")
            {
                if (sentenceIndex == 0)
                {
                    Pause(34);
                    return;
                }
            }

            if (dialog.name == "07_Fronicka_FirstQuest_End")
            {
                if (sentenceIndex == 21)
                {
                    Pause(36);
                    return;
                }
            }

            if (dialog.name == "Steve_Rose")
            {
                if (sentenceIndex == 0)
                {
                    Pause(43);
                    return;
                }
            }

            if (dialog.name == "Steve_WitchvillageReaction")
            {
                if (sentenceIndex == 0)
                {
                    Pause(48);
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