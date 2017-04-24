using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMusic : MonoBehaviour
{

    public int musicIndex;

    AudioTracker at;

    void Start ()
    {
        at = GameObject.Find("AudioTracker").GetComponent<AudioTracker>();
        at.SoundBoard(musicIndex);
    }

}
