using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public enum MaskType { Red,Green,Blue }
    public int maskIndex = 0;
    public SpriteRenderer playerSprite;
    public Mask currentMask;

     void Awake()
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

    /* I am like 90% sure this code lives in enemy script

    public bool CheckMaskCompatability(MaskType mask)
    {
        bool isRightMask = currentMask == mask;

        if(isRightMask)
        {
            Debug.Log("MASK TYPE MATCHED!!");
        }
        else
        {
            Debug.Log("Incoorect Mask Type");
        }

        return isRightMask;
    }
    */

    public void SwitchMask(int index)
    {
        List<Mask> inventory = PlayerManager.Instance.GetInventory();
        currentMask = inventory[index];
        if(currentMask.type==MaskType.Red) 
        {
            playerSprite.color = Color.green;
        }
        else if(currentMask==MaskType.Green){ 
            playerSprite.color =Color.blue;
        }
        else if(currentMask==MaskType.Blue) {
            playerSprite.color = Color.red;
        }
    }
}