using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public float speed = 2f;
    public static PlayerMovement instance;

    void Awake()
    {
        instance = this;
    }

    public void MovePlayer()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 dir = new Vector2(x, y);

        playerRb.linearVelocity = dir * speed;
    }

    void FixedUpdate()
    {
        if(!PlayerManager.Instance.CanMove())
        {
            playerRb.linearVelocity = Vector2.zero;
            return;
        }
        MovePlayer();
    }

}