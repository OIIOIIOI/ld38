using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveSprite : MonoBehaviour
{

    public Sprite[] alts;

    SpriteRenderer sr;

    int delay = 8;
    int tick = 0;
    List<Sprite> currentAlts;

    void Start ()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();

        currentAlts = new List<Sprite>(alts);
        ChangeSprite();
    }

    void Update ()
    {
        tick++;
        if (tick % delay == 0)
            ChangeSprite();
	}

    void ChangeSprite ()
    {
        int i = Random.Range(0, currentAlts.Count);
        sr.sprite = currentAlts[i];
        currentAlts.RemoveAt(i);

        if (currentAlts.Count == 0)
            currentAlts = new List<Sprite>(alts);
    }

}
