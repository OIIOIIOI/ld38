using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassRoom : MonoBehaviour
{

    public int roomMusicIndex;
    public Background background;

    public GameObject door;
    public GameObject[] lockedTriggers;
    public GameObject openTrigger;

    AudioTracker at;
    Global global;

    private void Awake()
    {
        at = GameObject.Find("AudioTracker").GetComponent<AudioTracker>();
        global = GameObject.Find("GLOBAL").GetComponent<Global>();
    }

    private void Start ()
    {
        at.RoomBoard(roomMusicIndex);

        int state = 0;
        if (global.IsClueValidated("compass1"))
            state += 1;
        if (global.IsClueValidated("compass2"))
            state += 2;
        if (global.IsClueValidated("compass3"))
            state += 4;
        
        background.Swap(state, 0f);

        if (state == 7)
        {
            foreach (GameObject go in lockedTriggers)
                go.SetActive(false);
            openTrigger.SetActive(true);
            door.SetActive(false);
        }
        else
        {
            foreach (GameObject go in lockedTriggers)
                go.SetActive(true);
            openTrigger.SetActive(false);
            door.SetActive(true);
        }
    }

}
