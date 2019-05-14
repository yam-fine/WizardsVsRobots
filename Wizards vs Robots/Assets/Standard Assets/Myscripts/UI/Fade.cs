using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class Fade : MonoBehaviour
{
    CanvasGroup cg;
    private void Awake()
    {
        cg = GetComponent<CanvasGroup>();
    }

    IEnumerator FadeCG(CanvasGroup cg, float start, float end, float lerpTime)
    {
        float timeStarted = Time.time;
        float currentTime;
        float percentComplete;

        while (true)
        {
            currentTime = Time.time - timeStarted;
            percentComplete = currentTime / lerpTime;

            float currentAlpha = Mathf.Lerp(start, end, percentComplete);

            cg.alpha = currentAlpha;

            if (percentComplete >= 1)
                break;

            yield return new WaitForEndOfFrame();
        }
    }

    public void FadeIn(float lerpTime)
    {
        StartCoroutine(FadeCG(cg, cg.alpha, 1, lerpTime));
    }

    public void FadeOut(float lerpTime)
    {
        StartCoroutine(FadeCG(cg, cg.alpha, 0, lerpTime));
    }
}