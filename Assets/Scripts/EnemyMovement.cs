using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    #region ENEMY_MOVEMENT

    public PlayerDetection playerDetection;
    public Transform[] patrolPoints;
    bool canMove = true;
    public float movementSpeed, waitDelay, patrolDuration;
    public bool stopped;

    void Start()
    {
        PatrolArea(true);
    }

    void FixedUpdate()
    {
        stopped = !playerDetection.canSeePlayerRightMask && playerDetection.canSeePlayer;
        if(stopped) transform.up = (PlayerMovement.instance.transform.position - transform.position).normalized;
    }

    public void PatrolArea(bool direction) //true = forward, false = backward
    {
        if(!canMove)
        {
            return;
        }

        Transform[] patrolPointsCopy = new Transform[patrolPoints.Length];
        System.Array.Copy(patrolPoints, patrolPointsCopy, patrolPoints.Length);
        if(!direction) System.Array.Reverse(patrolPointsCopy);

        StartCoroutine(PatrolArea_Coroutine(patrolPointsCopy));
    }

    IEnumerator PatrolArea_Coroutine(Transform[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
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

        StartCoroutine(PatrolArea_Coroutine(arr));
    }

    void RetraceDelay()
    {
        PatrolArea(false);
    }
    #endregion
}
