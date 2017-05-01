using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PaperTrigger : Trigger
{

    public GameObject fullPaper;

    override public void CustomScript (Trigger trigger)
    {
        fullPaper.SetActive(true);
    }

}
