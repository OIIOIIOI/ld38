using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PaperFullTrigger : Trigger
{

    override public void CustomScript (Trigger trigger)
    {
        gameObject.SetActive(false);
    }

}
