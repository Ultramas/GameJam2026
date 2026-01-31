using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum EnemyState
    {
        Stopped,
        Patroling,
        Chasing
    }

    public EnemyState state;
    public EnemyState previousState;
    public bool hasMask;
    public PlayerDetection Detection;
    public Mask curMask;
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
        if(curMask==null) return false;
        return curMask.type == PlayerManager.Instance.GetPlayerMask().type;
    }

    public void PlayerSpotted()
    {
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
}
