using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DurationBar : MonoBehaviour
{
    public UnityEvent OnTimeUp;

    public Image image;

    void Awake()
    {
        image = GetComponent<Image>();
    }

    public void StartDurationTimer(int num)
    {
        
        float duration = PlayerManager.Instance.GetPlayerMask().useDuration;
        // Reset fill
        image.fillAmount = 1f;

        // Cancel any existing tweens on this object
        LeanTween.cancel(gameObject);

        LeanTween.value(gameObject, 1f, 0f, duration)
            .setOnUpdate((float val) =>
            {
                image.fillAmount = val;
            })
            .setOnComplete(() =>
            {
                OnTimeUp?.Invoke(); //Invoke set mask null on PlayerManager
            });
    }
}
