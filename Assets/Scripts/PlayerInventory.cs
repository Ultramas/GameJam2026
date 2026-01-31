using UnityEngine;
using System.Collections.Generic;
public class PlayerInventory : MonoBehaviour
{
    public List<Mask> maskInventory = new List<Mask>();
    //POtential for other items???

    public List<Mask> GetInventory()
    {
        return maskInventory;
    }

    public void PickUpMask(Mask mask)
    {
        //add mask to inventory
        //Set new index for mask
    }
}
