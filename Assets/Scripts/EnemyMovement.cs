using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    
    #region ENEMY_MOVEMENT
    public Enemy manager;
    public Transform[] patrolPoints;
    public float movementSpeed, waitDelay, patrolDuration;
    int currentPatrolPointIndex = 0;
    bool curPatrolDirection = true;
    bool stopped;

    IEnumerator patrolArea_coroutine;

    void Start()
    {
        manager.state = Enemy.EnemyState.Patroling;
        PatrolArea(curPatrolDirection);
    }

    void FixedUpdate()
    {
        stopped = false;
        if(manager.state == Enemy.EnemyState.Stopped) 
        {
            stopped = true;
            LookAtPlayer();
        }
        else if(manager.state == Enemy.EnemyState.Chasing)
        {
            ChasePlayer();
        }
        else if(manager.state == Enemy.EnemyState.Patroling)
        {
            StartPatroling();
        }
    }
    
    public void ChasePlayer()
    {
        LookAtPlayer();
        MoveTowardsPlayer();
        StopPatroling();
        //Camera effects, music, what have you
    }

    void StartPatroling()
    {
        if(patrolArea_coroutine==null)
        {
            PatrolArea(true);
        }
    }

    void StopPatroling()
    {
        if(patrolArea_coroutine!=null)
        {
            StopCoroutine(patrolArea_coroutine);
            patrolArea_coroutine=null;
        }
    }

    public void MoveTowardsPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, PlayerManager.Instance.gameObject.transform.position, movementSpeed * Time.deltaTime);
    }

    public void LookAtPlayer()
    {
        transform.up = (PlayerMovement.instance.transform.position - transform.position).normalized;
    }

    public void PatrolArea(bool direction) //true = forward, false = backward
    {
        Transform[] patrolPointsCopy = new Transform[patrolPoints.Length];
        System.Array.Copy(patrolPoints, patrolPointsCopy, patrolPoints.Length);
        if(!direction) System.Array.Reverse(patrolPointsCopy);

        patrolArea_coroutine = PatrolArea_Coroutine(patrolPointsCopy);

        StartCoroutine(patrolArea_coroutine);
    }

    IEnumerator PatrolArea_Coroutine(Transform[] arr)
    {
        for (int i = currentPatrolPointIndex; i < arr.Length; i++)
        {
            currentPatrolPointIndex = i;

            float timeElapsed = 0f;
            float completion = 0f;
            Vector3 start = arr[i].position;
            Vector3 end = arr[(i+1) % arr.Length].position;
            Vector3 startUp = transform.up;
            Vector3 dir = (end - start).normalized;

            while(timeElapsed < patrolDuration)
            {
                if(!stopped) 
                {
                    timeElapsed += Time.deltaTime;
                    completion = timeElapsed / patrolDuration;
                    transform.position = Vector3.Lerp(start, end, completion);
                    transform.up = Vector3.Lerp(startUp, dir, Mathf.Clamp01(completion*4));
                }
                yield return null;
            }
        }

        currentPatrolPointIndex = 0;
        patrolArea_coroutine = PatrolArea_Coroutine(arr);
        StartCoroutine(patrolArea_coroutine);
    }

    void RetraceDelay()
    {
        curPatrolDirection = false;
        PatrolArea(curPatrolDirection);
    }
    #endregion
}
