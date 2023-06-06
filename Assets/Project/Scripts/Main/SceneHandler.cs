using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Main
{
    public class SceneHandler : Singleton<SceneHandler>
    {
        public bool PlayOnStart;

        private Animator anim;
        private string sceneName;
        
        protected override void Awake()
        {
            base.Awake();
            anim = GetComponent<Animator>();
        }

        private void Start()
        {
            if(PlayOnStart)
            {
                PlayOnStart = false;
                Play();
            }
        }

        private void Play(FadeMode mode = FadeMode.FadeOut)
        {
            if(mode == FadeMode.FadeOut) anim.SetTrigger("FadeOut");
            else
            {
                DisablePlayer();
                anim.SetTrigger("FadeIn");
            }
        }

        private void DisablePlayer()
        {
            GameObject player = GameObject.FindWithTag("Player");
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<PlayerInteractions>().enabled = false;
        }
        
        public void EnterNewScene(string sceneName)
        {
            this.sceneName = sceneName;
            PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);
            Play(FadeMode.FadeIn);
        }

        public void LoadScene()
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public enum FadeMode
    {
        FadeIn,
        FadeOut
    }
}