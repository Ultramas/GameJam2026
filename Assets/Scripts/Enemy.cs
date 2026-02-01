using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public enum EnemyState
    {
        Stopped,
        Patroling,
        Chasing,
        Attack
    }

    public EnemyState state;
    public EnemyState previousState;
    public bool hasMask;
    public PlayerDetection Detection;
    public Mask curMask;
    public UnityEvent OnPlayerHit;
    public EnemyState GetState()
    {
        return state;
    }

    public void SetEnemyState(EnemyState newState)
    {
        previousState = state;
        state = newState;
    }

    public bool CheckPlayerMask()
    {
        if(curMask==null || PlayerManager.Instance.GetPlayerMask() == null) return false;
        return curMask.type == PlayerManager.Instance.GetPlayerMask().type;
    }

    public void PlayerSpotted()
    {
        if(state == EnemyState.Attack)
        {
            return;
        }
        if(!hasMask)
        {
            SetEnemyState(EnemyState.Chasing);
        }
        else if(CheckPlayerMask())
        {
            SetEnemyState(EnemyState.Stopped);
        }
        else if(!CheckPlayerMask())
        {
            SetEnemyState(EnemyState.Chasing);
        }
        Debug.Log("Enemy State: " + state);
    }

    public void ResetMovement()
    {
        SetEnemyState(EnemyState.Patroling);
        Debug.Log("Resetting State");
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.collider.tag == "Player")
        {
            Debug.Log("Collided With Player");
            SetEnemyState(EnemyState.Attack);
            OnPlayerHit?.Invoke();
        }    
    }
}
