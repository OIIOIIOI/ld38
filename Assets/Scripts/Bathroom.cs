using System.Collections;
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
        at.EnterRoom(roomMusicIndex);
        Invoke("Lightning", Random.Range(8f, 20f));
        //Invoke("Lightning", 1f);
    }

    void Lightning ()
    {
        background.Flash(0, 0, 0, Random.Range(0.1f, 0.6f));
        global.ValidateClue("bathroom", roomMusicIndex);

        Invoke("LightningSFX", Random.Range(0.8f, 1.6f));
        Invoke("Lightning", Random.Range(8f, 20f));
        //Invoke("Lightning", 6f);
    }

    void LightningSFX ()
    {
        at.PlaySFX(10);
    }

}
