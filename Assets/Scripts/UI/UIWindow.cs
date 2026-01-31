using UnityEngine;
using UnityEngine.Events;

public class UIWindow : MonoBehaviour
{
    public GameObject window;
    public bool isOpen;
    public UnityEvent OnWindowClose; //So we can have drop anim play before ui disable
    public UnityEvent OnWindowOpen; //So we can alert mask display to be hidden

    public void Open()
    {
        OnWindowOpen?.Invoke();
        window.SetActive(true);
    }

    public void Close()
    {
        OnWindowClose?.Invoke();
        Invoke("DisableAfterDelay", 2f);
    }

    public void DisableAfterDelay()
    {
        window.SetActive(false);
    }
}