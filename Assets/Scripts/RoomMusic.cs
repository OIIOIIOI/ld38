using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMusic : MonoBehaviour
{

    public int roomMusicIndex;

    AudioTracker at;

    void Awake()
    {
        at = GameObject.Find("AudioTracker").GetComponent<AudioTracker>();
    }

    void Start ()
    {
        at.EnterRoom(roomMusicIndex);
    }

}
