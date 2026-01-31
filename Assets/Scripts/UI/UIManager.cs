using UnityEngine;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public List<UIWindow> UIWindowsList;

    private void Awake() 
    {
        if(Instance == null)
        {
            Instance = this;
        }    
        else
        {
            Destroy(Instance);
        }
    }
    public void OpenWindow(int index)
    {
        UIWindowsList[index].Open();
    }
}