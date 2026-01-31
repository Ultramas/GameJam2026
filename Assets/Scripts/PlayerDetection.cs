using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerDetection : MonoBehaviour
{
    public float normalIntensity = 1f;
    public float seeIntensity = 5f;
    public float detectRange = 10f;
    public float detectArc = 90f;
    public Light2D visibilityConeLight;
    public LayerMask layerMask;
    public GameManager.MaskType myMaskType;
    public bool canSee;
    public bool canSeePlayer;
    public bool canSeePlayerRightMask;
    public bool inArc;

    public void FixedUpdate()
    {
        Vector3 dir = PlayerMovement.instance.transform.position - transform.position;
        float dist = Mathf.Min(dir.magnitude, detectRange);
        dir.Normalize();

        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, dist, layerMask);
        canSee = hit.collider!=null && LayerMask.NameToLayer("player") == hit.collider.gameObject.layer;
        inArc = Vector3.Angle(transform.up, dir) < detectArc/2f;

        canSeePlayer = canSee && inArc;
        canSeePlayerRightMask = canSeePlayer && myMaskType != GameManager.Instance.currentMask;
        
        visibilityConeLight.intensity = canSeePlayer ? seeIntensity : normalIntensity;
    }
}
