using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChapelDoorTrigger : Trigger
{

    override protected void CustomScript (Trigger trigger)
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
