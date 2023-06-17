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
        private Transform player;
        
        protected override void Awake()
        {
            base.Awake();
            anim = GetComponent<Animator>();
            player = FindObjectOfType<PlayerMovement>().transform;
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
            else anim.SetTrigger("FadeIn");
        }

        public void EnterNewScene(string sceneName)
        {
            this.sceneName = sceneName;
            PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);
            GameStateManager.Instance.ChangeGameState(GameState.InTeleportation);
            Play(FadeMode.FadeIn);
            GameManager.Instance.SaveLastSceneInfo();
            GameManager.Instance.SaveCurrentSceneInfo();
        }

        public void LoadScene()
        {
            if (sceneName == "Village" && GameManager.Instance.Data.WitchVillage)
            {
                SceneManager.LoadScene("WitchVillage");
                GameManager.Instance.Data.WitchVillage = false;
                GameManager.Instance.Data.NpcInfos[1].DialogIndex = 4;
                GameManager.Instance.Save();
                return;
            }
            SceneManager.LoadScene(sceneName);
        }
    }

    public enum FadeMode
    {
        FadeIn,
        FadeOut
    }
}