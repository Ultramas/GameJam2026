
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public float speed = 2f;
    public static PlayerMovement instance;
    public Animator animator;

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

        // set animator values with movement
        bool moving = Mathf.Abs(x) > 0.01f || Mathf.Abs(y) > 0.01f;
        animator.SetBool("moving", moving);

        if(moving) transform.rotation = Quaternion.LookRotation(Vector3.forward, dir.normalized);
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