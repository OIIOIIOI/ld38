using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMusic : MonoBehaviour
{

    public int musicIndex;

    AudioTracker at;

    void Start ()
    {
        GameObject go = GameObject.Find("Scriptable");
        if (go)
            at = go.GetComponent<AudioTracker>();
        if (at)
            at.SoundBoard(musicIndex);
    }

}
