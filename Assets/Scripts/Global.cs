using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{

    public static Global instance = null;

    AudioTracker at;

    List<string> foundClues = new List<string>();

    public int compassRotationA;
    public int compassRotationB;
    public int compassRotationC;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        at = GameObject.Find("AudioTracker").GetComponent<AudioTracker>();

        DontDestroyOnLoad(gameObject);
    }

    public void ValidateClue(string id)
    {
        if (!foundClues.Contains(id))
        {
            foundClues.Add(id);
            Debug.Log(id + " ok, found: " + GetProgress());
            at.PuzzleBoard(GetProgress());
        }
    }

    public void InvalidateClue (string id)
    {
        if (foundClues.Contains(id))
        {
            foundClues.Remove(id);
            Debug.Log(id + " ok, unfound: " + GetProgress());
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
