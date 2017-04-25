using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChapelDoorTrigger : Trigger
{

    AudioTracker at;
    Global global;

    private void Awake()
    {
        at = GameObject.Find("AudioTracker").GetComponent<AudioTracker>();
        global = GameObject.Find("GLOBAL").GetComponent<Global>();
    }

    //new void Start()
    //{
        //base.Start();
    //}

    override protected void CustomScript ()
    {
        if (global.IsClueValidated("compass1") &&
            global.IsClueValidated("compass2") &&
            global.IsClueValidated("compass3"))
        {
            SceneManager.LoadScene(targetScene.ToString());
        }
        else
        {
            Debug.Log("locked");
            // TODO locked messages
        }
    }

}
