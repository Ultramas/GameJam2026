using UnityEngine;
using System.Collections.Generic;
public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    public PlayerInventory inventory;
    public Mask curMask;
    [SerializeField] private bool canMove;
    public int health = 100;

    [SerializeField] private int SWITCH_MASK_MENU_INDEX; 

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

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Space)) //Later we add check to see if we are in menu
        {
            Debug.Log("Opening Switch Mask UI");
            OpenMaskSwitchUI();
        }
    }

    public Mask GetPlayerMask()
    {
        return curMask;
    } 

    public void SetCurMask(int index)
    {
        curMask = inventory.GetInventory()[index];
    }

    public List<Mask> GetInventory()
    {
        return inventory.GetInventory();
    }

    public void SetMoveState(bool state)
    {
        canMove = state;
    }

    public bool CanMove()
    {
        return canMove;
    }

    public void OpenMaskSwitchUI()
    {
        //SetMoveState(false); temporary
        UIManager.Instance.OpenWindow(SWITCH_MASK_MENU_INDEX);
    }

}
