/* Moving logic to player manager. -Sam

using UnityEngine;
using UnityEngine.Events;

public class MaskSwitch : MonoBehaviour
{
    public UnityEvent<int> OnMaskSwitch;
    

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Opening Mask Switching UI!");
            OnMaskSwitch?.Invoke();
        }   
    }
}
*/