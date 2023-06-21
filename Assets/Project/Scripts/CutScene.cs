using System;
using Main;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene : Singleton<CutScene>
{
    private const string saveDataPath = "SaveData";
    public AudioSource Source;
    public Animator transition;

    protected override void Awake()
    {
        base.Awake();
        SaveData data = JsonUtility.FromJson<SaveData>(PlayerPrefs.GetString(saveDataPath));
        if (data.LastScene != null)
        {
            SceneManager.LoadScene(data.LastScene.Name);
        }
    }

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
