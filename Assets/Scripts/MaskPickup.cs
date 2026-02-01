using UnityEngine;
using UnityEngine.Events;
public class MaskPickup : MonoBehaviour
{
    public Mask mask;
    public SpriteRenderer rend;
    bool playerInArea = false;
    public UnityEvent<Mask> OnPickUpMask;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Player in area, waiting for interact button...");
            playerInArea = true;
        }
    }


    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.E) && playerInArea)
        {
            rend.enabled = false;
            OnPickUpMask?.Invoke(mask);
        }    
    }
}
