using Main;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : Singleton<Music>
{
    public AudioSource Source;
    public AudioClip[] Clips;

    protected override void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        base.Awake();
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        Source.loop = true;
        Source.Play();
    }
}
