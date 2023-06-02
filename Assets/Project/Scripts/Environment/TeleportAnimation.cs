using System;
using System.Collections;
using Main;
using UnityEngine;
using UnityEngine.UI;

namespace Environment
{
     public class TeleportAnimation : Singleton<TeleportAnimation>
     {
         public event Action OnTeleportAnimationDone;
         public event Action OnTeleportAnimationStart;
         public event Action OnTeleport;
         
         public float FadeDuration;
         public float DarkTime = 0.5f;
         public Image FadeImage;
         
         [HideInInspector] public bool isTeleporting;
         private FadeMode mode = FadeMode.FadeIn;
         private float alpha;
         
         private void Update()
         {
             if (!isTeleporting) return;
     
             Fade();
         }
     
         private void Fade()
         {
             if (mode == FadeMode.FadeIn)
             {
                 alpha += 1 / FadeDuration * Time.deltaTime;
     
                 if (alpha >= 1) alpha = 1f;
                 
                 FadeImage.color = new Color(
                     FadeImage.color.r,
                     FadeImage.color.g,
                     FadeImage.color.b,
                     alpha
                 );
             }
             else if (mode == FadeMode.FadeOut)
             {
                 alpha -= 1 / FadeDuration * Time.deltaTime;
     
                 if (alpha <= 0) alpha = 0f;
                 
                 FadeImage.color = new Color(
                     FadeImage.color.r,
                     FadeImage.color.g,
                     FadeImage.color.b,
                     alpha
                 );
             }
         }

         public void StartTeleportation()
         {
             if (isTeleporting) return;
             StartCoroutine(TeleportCooldown());
         }
         private IEnumerator TeleportCooldown()
         {
             OnTeleportAnimationStart?.Invoke();
             isTeleporting = true;
             mode = FadeMode.FadeIn;
             yield return new WaitForSeconds(FadeDuration);
             OnTeleport?.Invoke();
             yield return new WaitForSeconds(DarkTime);
             mode = FadeMode.FadeOut;
             yield return new WaitForSeconds(FadeDuration);
             isTeleporting = false;
             OnTeleportAnimationDone?.Invoke();
         }
     
         private enum FadeMode
         {
             FadeIn,
             FadeOut
         }
     }   
}