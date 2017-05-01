using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnsClue : MonoBehaviour
{

    public int roomMusicIndex;
    public Background background;
    public SpriteRenderer number;

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

        mouseScript.MouseCursor(9);

        number.gameObject.SetActive(false);
    }

    public void ToggleCandles (bool isOn)
    {
        if (isOn)
        {
            number.gameObject.SetActive(true);
            background.Swap(0, 0.15f);

            if (!global.IsClueValidated("columns"))
            {
                global.ValidateClue("columns");
                at.SfxBoard(9);
            }
        }
        else
        {
            number.gameObject.SetActive(false);
            background.Swap(1, 0.15f);
        }
    }

}
