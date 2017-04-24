using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{

    public static Global instance = null;
    
    public Texture2D CandleOnIcon;
    public Texture2D CandleOffIcon;
    public Texture2D GoForwardUpIcon;
    public Texture2D GoRightIcon;
    public Texture2D GoBackwardDownIcon;
    public Texture2D GoLeftIcon;
    public Texture2D RotateIcon;
    public Texture2D LookAtIcon;
    public Texture2D UseIcon;

    AudioTracker at;

    List<string> foundClues = new List<string>();

    void Awake ()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        at = GameObject.Find("AudioTracker").GetComponent<AudioTracker>();

        DontDestroyOnLoad(gameObject);
    }

    public void ValidateClue (string id, int room)
    {
        if (!foundClues.Contains(id))
        {
            foundClues.Add(id);
            at.EnterRoom(room);
        }
        Debug.Log(id + " - " + foundClues.Count);
    }

    public int GetProgress ()
    {
        return foundClues.Count;
    }

}
