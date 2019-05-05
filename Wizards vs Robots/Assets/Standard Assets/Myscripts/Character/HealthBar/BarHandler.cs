using UnityEngine;
using UnityEngine.UI;

public class BarHandler : MonoBehaviour
{
    [SerializeField] float lerpSpeed = 3f;
    [SerializeField] Image bar;
    float fillamount;

    public float MaxValue { get; set; }
    public float Value { set { fillamount = value / MaxValue; } }

    private void Update()
    {
        HandleBar();
    }

    void HandleBar()
    {
        if (bar.fillAmount != fillamount)
            bar.fillAmount = Mathf.Lerp(bar.fillAmount, fillamount, Time.deltaTime * lerpSpeed);
    }
}