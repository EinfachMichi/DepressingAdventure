using Main;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tutorial : Singleton<Tutorial>
{
    public GameObject MapTutorial;
    
    public void ShowMapTutorial()
    {
        MapTutorial.SetActive(true);
    }

    public void CloseMapTutorial(InputAction.CallbackContext context)
    {
        if(context.started) MapTutorial.SetActive(false);
    }
}
