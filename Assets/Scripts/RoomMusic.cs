using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMusic : MonoBehaviour
{

    public int roomMusicIndex;

    AudioTracker at;
    Global global;

    void Awake()
    {
        at = GameObject.Find("AudioTracker").GetComponent<AudioTracker>();
        global = GameObject.Find("GLOBAL").GetComponent<Global>();
    }

    void Start ()
    {
        at.PuzzleBoard(global.GetProgress());
        at.RoomBoard(roomMusicIndex);
    }

}
