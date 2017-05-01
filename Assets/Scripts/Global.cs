using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{

    public static Global instance = null;

    AudioTracker at;

    List<string> foundClues = new List<string>();

    public int compassRotationA = 3;
    public int compassRotationB = 0;
    public int compassRotationC = 1;

    public bool firstCandleOn = false;
    public bool thirdCandleOn = false;

    public int lockNumberA = 3;
    public int lockNumberB = 4;
    public int lockNumberC = 6;

    void Awake ()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        at = GameObject.Find("AudioTracker").GetComponent<AudioTracker>();

        DontDestroyOnLoad(gameObject);
    }

    public void ResetAll ()
    {
        compassRotationA = 3;
        compassRotationB = 0;
        compassRotationC = 1;
        lockNumberA = 3;
        lockNumberB = 4;
        lockNumberC = 6;
        firstCandleOn = false;
        thirdCandleOn = false;
        foundClues.Clear();
    }

    public void ValidateClue (string id)
    {
        if (!foundClues.Contains(id))
        {
            foundClues.Add(id);
            at.PuzzleBoard(GetProgress());

            if (id.Contains("compass"))
            {
                if (IsClueValidated("compass1") && IsClueValidated("compass2") && IsClueValidated("compass3"))
                    at.SfxBoard(9);
            }
        }
    }

    public void InvalidateClue (string id)
    {
        if (foundClues.Contains(id))
        {
            foundClues.Remove(id);
            at.PuzzleBoard(GetProgress());
        }
    }

    public bool IsClueValidated (string id)
    {
        return foundClues.Contains(id);
    }

    public int GetProgress ()
    {
        return foundClues.Count + 1;
    }

}
