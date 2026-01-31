using UnityEngine;
using UnityEngine.UI;
public class CurMaskUI : MonoBehaviour
{
    public LeanTweenType openEase;
    public LeanTweenType hiddenEase;

    public Image maskDisplayImage;
    public Transform normalPos, hiddenPos;
    public float animDuration;

    private void Start() 
    {
        maskDisplayImage.sprite = PlayerManager.Instance.GetPlayerMask().sprite;    
    }
    public void Open()
    {
        LeanTween.move(this.gameObject, normalPos.position, animDuration).setEase(openEase);
    }

    public void Hide()
    {
        LeanTween.move(this.gameObject, hiddenPos.position, animDuration).setEase(hiddenEase);
    }

    public void UpdateMaskDisplay()
    {
        maskDisplayImage.sprite = PlayerManager.Instance.GetPlayerMask().sprite;
    }
}
