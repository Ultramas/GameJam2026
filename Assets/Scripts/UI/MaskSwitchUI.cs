using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;

public class MaskSwitchUI : MonoBehaviour
{
    //masks will be pulled from GameManager
    List<Mask> masks = new List<Mask>();
    //current mask index will be pulled from GaemManager
    int curMaskIndex;
    public GameObject animationParent;
    public Transform openPos, closePos;
    public float animDuration;
    public UnityEvent<int> OnMaskSelected;
    public Image maskDisplayImg;
    Sprite curMaskSprite;

    public LeanTweenType openEase;
    public LeanTweenType closeEase;

    //Ngl bruh, it is hella late. I am super tired. I really don't think imma be able to explain how any of 
    //this wors tomorrow lmao 
    private void OnEnable() 
    {
        Setup();
        OpenAnim();
    }
    
    public void Setup()
    {
        masks = PlayerManager.Instance.GetInventory(); //returns a list of masks
        //curMaskIndex = PlayerManager.Instance.GetPlayerMask().GetIndex(); //get the current mask, then get it's index
        //maskDisplayImg.sprite = masks[curMaskIndex].sprite; //set the image sprtite
    }

    void OpenAnim()
    { 
        LeanTween.move(animationParent, openPos, animDuration).setEase(openEase);
    }

    public void CloseAnim()
    {
        LeanTween.move(animationParent, closePos, animDuration).setEase(closeEase);
    }

    void SwitchMask(int dir)
    {
        if(masks.Count <= 1)
        {
            return;
        }

        curMaskIndex = (curMaskIndex + dir + masks.Count) % masks.Count;

        Debug.Log("Index: " + curMaskIndex);

        curMaskSprite = masks[curMaskIndex].sprite;
        SetMaskImage(curMaskSprite);
    }

    void SetMaskImage(Sprite mask)
    {
        //Little leentween animation
        maskDisplayImg.rectTransform.localScale = Vector2.zero;
        LeanTween.scale(maskDisplayImg.gameObject, Vector3.one, 0.2f).setEase(LeanTweenType.easeOutBack);
        maskDisplayImg.sprite = mask;
    }

    public void SelectMask()
    {
        if(masks[curMaskIndex].isInColldown)
        {
            //Debug.Log("Cooling Down");
            return;
        }
        //SetMask on GameManager -> SetMask for player
        Debug.Log("Selecting mask.." + masks[curMaskIndex].gameObject.name);
        OnMaskSelected?.Invoke(curMaskIndex);
    }

    public void OnMaskUsed()
    {
        OnMaskSelected?.Invoke(-1);
    }

    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SwitchMask(1);
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            SwitchMask(-1);
        }
    }
}