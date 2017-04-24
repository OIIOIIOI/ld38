using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassTrigger : Trigger
{

    public int startRotation;
    public int correctRotation;

    bool rotating = false;

    AudioTracker at;
    Global global;

    private void Awake()
    {
        at = GameObject.Find("AudioTracker").GetComponent<AudioTracker>();
        global = GameObject.Find("GLOBAL").GetComponent<Global>();
    }

    new void Start ()
    {
        base.Start();

        transform.Rotate(Vector3.forward, -90f * startRotation);
    }

    override protected void CustomScript ()
    {
        if (!rotating)
        {
            rotating = true;
            //at.PlaySFX(5);
            at.SoundBoard(0, -1, 5);
            StartCoroutine("RotateWheel");
        }
    }

    IEnumerator RotateWheel ()
    {
        for (float f = 0f; f <= 1f; f += 0.1f)
        {
            transform.Rotate(Vector3.forward, -9f);
            yield return new WaitForFixedUpdate();
        }
        rotating = false;
        yield return null;
    }

}
