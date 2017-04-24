﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bathroom : MonoBehaviour
{

    public int roomMusicIndex;
    public Background background;

    AudioTracker at;
    Global global;

    private void Awake ()
    {
        at = GameObject.Find("AudioTracker").GetComponent<AudioTracker>();
        global = GameObject.Find("GLOBAL").GetComponent<Global>();
    }

    private void Start ()
    {
        at.RoomBoard(roomMusicIndex);
        Invoke("Lightning", Random.Range(8f, 20f));
        //Invoke("Lightning", 1f);
    }

    void Lightning ()
    {
        background.Flash(0, 0.3f, 0.15f, 0.05f);
        global.ValidateClue("bathroom");

        Invoke("LightningSFX", Random.Range(0.2f, 0.6f));
        Invoke("Lightning", Random.Range(8f, 20f));
    }

    void LightningSFX ()
    {
        at.SfxBoard(10);
    }

}
