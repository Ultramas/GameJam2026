using UnityEngine;

public class Mask : MonoBehaviour
{
    public int maskIndex; //Will make it private again once mask index is determined by code
    public Sprite sprite;
    public GameManager.MaskType type;
    public float useDuration;

    public void SetMaskIndex(int index)
    {
        maskIndex = index;
    }

    public int GetIndex()
    {
        return maskIndex;
    }
}
