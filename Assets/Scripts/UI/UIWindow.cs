using UnityEngine;
using UnityEngine.Events;

public class UIWindow : MonoBehaviour
{
    public GameObject window;
    public bool isOpen;
    public UnityEvent OnWindowClose;

    public void Open()
    {
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