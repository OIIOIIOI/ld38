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

    public void Swap (int index = 0, float fadeInStep = 0.01f)
    {
        StopAllCoroutines();

        if (sr != null && alts.Length > index && alts[index] != null)
            StartCoroutine(SwapSprite(alts[index], fadeInStep));
    }

    public void Flash (int index = 0, float fadeInStep = 0.05f, float fadeOutStep = 0.05f, float flashTime = 0.1f)
    {
        StopAllCoroutines();

        if (sr != null && alts.Length > index && alts[index] != null)
            StartCoroutine(BlinkSprite(alts[index], fadeInStep, fadeOutStep, flashTime));
    }

    IEnumerator SwapSprite (Sprite s, float fadeInStep)
    {
        sr.color = Color.clear;
        sr.sprite = s;

        for (float f = 0f; f <= 1f; f += 0.1f)
        {
            sr.color = new Color(1, 1, 1, f);
            yield return new WaitForSeconds(fadeInStep);
        }

        if (swapTarget)
            swapTarget.sprite = s;
        sr.color = Color.clear;
        sr.sprite = null;
        yield return null;
    }

    IEnumerator BlinkSprite (Sprite s, float fadeInStep, float fadeOutStep, float flashTime)
    {
        sr.color = Color.clear;
        sr.sprite = s;

        for (float f = 0f; f <= 1f; f += 0.1f)
        {
            sr.color = new Color(1, 1, 1, f);
            if (fadeInStep >= 0f)
                yield return new WaitForSeconds(fadeInStep);
            else
                yield return new WaitForFixedUpdate();
        }

        yield return new WaitForSeconds(flashTime);

        for (float f = 1f; f >= 0; f -= 0.1f)
        {
            sr.color = new Color(1, 1, 1, f);
            if (fadeInStep >= 0f)
                yield return new WaitForSeconds(fadeInStep);
            else
                yield return new WaitForFixedUpdate();
        }

        sr.color = Color.clear;
        sr.sprite = null;
        yield return null;
    }

}
