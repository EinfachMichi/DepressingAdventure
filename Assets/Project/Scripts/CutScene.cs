using System;
using Main;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene : Singleton<CutScene>
{
    public AudioSource Source;
    public Animator transition;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Play()
    {
        Source.Play();
        Invoke("EnterNewScene", Source.clip.length - 1f);
    }

    public void EnterNewScene()
    {
        transition.SetTrigger("Trigger");
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
