using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteRoom : MonoBehaviour
{

    public int roomMusicIndex;
    public Background background;
    public GameObject door;
    public GameObject[] lockedTriggers;
    public GameObject openTrigger;
    public CandleTrigger candle1;
    public CandleTrigger candle3;

    AudioTracker at;
    Global global;
    MouseScript mouseScript;

    float speed = 0.08f;

    private void Awake ()
    {
        at = GameObject.Find("AudioTracker").GetComponent<AudioTracker>();
        global = GameObject.Find("GLOBAL").GetComponent<Global>();
        mouseScript = GameObject.Find("GLOBAL").GetComponent<MouseScript>();
    }

    private void Start ()
    {
        at.RoomBoard(roomMusicIndex);

        speed = 0;
        RefreshView();
        speed = 0.08f;

        mouseScript.MouseCursor(9);
    }

    void RefreshView ()
    {
        int view = 0;
        if (global.firstCandleOn && !global.thirdCandleOn) view = 2;
        if (global.thirdCandleOn && !global.firstCandleOn) view = 1;
        if (global.firstCandleOn && global.thirdCandleOn)
        {
            view = 3;
            openTrigger.SetActive(true);
            foreach (GameObject go in lockedTriggers)
                go.SetActive(false);
            door.SetActive(false);

            if (!global.IsClueValidated("whiteroom"))
            {
                global.ValidateClue("whiteroom");
                at.SfxBoard(9);
            }
        }
        else
        {
            openTrigger.SetActive(false);
            foreach (GameObject go in lockedTriggers)
                go.SetActive(true);
            door.SetActive(true);
            global.InvalidateClue("whiteroom");
        }

        mouseScript.MouseCursor(9);
        background.Swap(view, speed);
    }

    public void ToggleCandle (string candle)
    {
        RefreshView();
    }

    public void ResetRoom ()
    {
        at.SfxBoard(8);

        global.firstCandleOn = false;
        global.thirdCandleOn = false;

        candle1.ResetIcon();
        candle3.ResetIcon();

        Invoke("RefreshView", 0.35f);
    }

}
