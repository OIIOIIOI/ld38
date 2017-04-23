using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bathroom : MonoBehaviour
{

    public Background background;

    AudioTracker at;

    private void Start ()
    {
        GameObject go = GameObject.Find("Scriptable");
        if (go)
            at = go.GetComponent<AudioTracker>();

        InvokeRepeating("Lightning", 3f, 3f);
    }

    void Lightning ()
    {
        background.Flash(0, 0, 0, Random.Range(0.1f, 0.6f));

        if (at)
            Invoke("LightningSFX", Random.Range(0.5f, 1.5f));
    }

    void LightningSFX ()
    {
        at.SoundBoard(0, 0, 10);
    }

}
