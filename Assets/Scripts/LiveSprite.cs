using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveSprite : MonoBehaviour
{

    public int delay;
    public Sprite[] alts;

    SpriteRenderer sr;

    int tick = 0;
    List<Sprite> currentAlts;

    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();

        currentAlts = new List<Sprite>(alts);
        changeSprite();
    }

    void Update ()
    {
        tick++;
        if (tick % delay == 0)
            changeSprite();
	}

    void changeSprite ()
    {
        int i = Random.Range(0, currentAlts.Count);
        sr.sprite = currentAlts[i];
        currentAlts.RemoveAt(i);

        if (currentAlts.Count == 0)
            currentAlts = new List<Sprite>(alts);
    }

}
