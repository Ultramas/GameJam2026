using UnityEngine;
using System.Collections;

public class Mask : MonoBehaviour
{
    public int maskIndex; //Will make it private again once mask index is determined by code
    public Sprite sprite;
    public GameManager.MaskType type;
    public float useDuration;
    public float coolDownDuration;
    public bool isInColldown = false;

    public void SetMaskIndex(int index)
    {
        maskIndex = index;
    }

    public void StartCooldown()
    {
        StartCoroutine(CoolDownCoroutine());
    }

    public IEnumerator CoolDownCoroutine()
    {
        isInColldown = true;
        yield return new WaitForSeconds(coolDownDuration);
        isInColldown = false;
    }

    public int GetIndex()
    {
        return maskIndex;
    }
}
