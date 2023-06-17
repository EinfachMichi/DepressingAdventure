using System;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource Source;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        
        Source.loop = true;
        Source.Play();
    }
}
