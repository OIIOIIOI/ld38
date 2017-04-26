using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    public Sprite[] alts;
    public SpriteRenderer swapTarget;

    SpriteRenderer sr;

    private void Awake ()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    public void Swap (int index = 0, float fadeInStep = 0.1f)
    {
        StopAllCoroutines();

        if (sr != null && alts.Length > index && alts[index] != null)
            StartCoroutine(SwapSprite(alts[index], fadeInStep));
    }

    public void Flash (int index = 0, float fadeInStep = 0.1f, float fadeOutStep = 0.1f, float flashTime = 0.1f)
    {
        StopAllCoroutines();

        if (sr != null && alts.Length > index && alts[index] != null)
            StartCoroutine(BlinkSprite(alts[index], fadeInStep, fadeOutStep, flashTime));
    }

    IEnumerator SwapSprite (Sprite s, float fadeInStep)
    {
        sr.color = new Color(1f, 1f, 1f, 0f);
        sr.sprite = s;

        if (fadeInStep > 0f)
        {
            for (float f = 0f; f <= 1f; f += fadeInStep)
            {
                sr.color = new Color(1f, 1f, 1f, f);
                yield return new WaitForFixedUpdate();
            }
            sr.color = Color.white;
        }

        if (swapTarget)
            swapTarget.sprite = s;

        sr.color = new Color(1f, 1f, 1f, 0f);
        sr.sprite = null;

        yield return null;
    }

    IEnumerator BlinkSprite (Sprite s, float fadeInStep, float fadeOutStep, float flashTime)
    {
        sr.color = Color.clear;
        sr.sprite = s;

        for (float f = 0f; f <= 1f; f += fadeInStep)
        {
            sr.color = new Color(1f, 1f, 1f, f);
            yield return new WaitForFixedUpdate();
        }
        sr.color = new Color(1, 1, 1, 1);

        if (flashTime > 0f)
            yield return new WaitForSeconds(flashTime);

        for (float f = 1f; f >= 0f; f -= fadeOutStep)
        {
            sr.color = new Color(1f, 1f, 1f, f);
            yield return new WaitForFixedUpdate();
        }

        sr.color = Color.clear;
        sr.sprite = null;
        yield return null;
    }

}
