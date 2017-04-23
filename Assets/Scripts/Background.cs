using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    public Sprite[] alts;

    SpriteRenderer sr;
    Color alphaWhite = new Color(1, 1, 1, 0);

    private void Awake ()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    public void Swap (int index = 0)
    {
        StopAllCoroutines();

        if (sr != null && alts.Length > index && alts[index] != null)
            StartCoroutine(SwapSprite(alts[index]));
    }

    IEnumerator SwapSprite (Sprite s)
    {
        sr.color = alphaWhite;
        sr.sprite = s;
        sr.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        sr.color = alphaWhite;
        yield return null;
    }

}
