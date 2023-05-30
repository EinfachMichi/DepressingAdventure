using UnityEngine;
using UnityEngine.Events;

public abstract class Event : MonoBehaviour
{
    public UnityEvent UnityEvent;

    public void TriggerEvent()
    {
        UnityEvent.Invoke();
    }
}
