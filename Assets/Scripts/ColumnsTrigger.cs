using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ColumnsTrigger : Trigger
{

    public ColumnsClue roomScript;

    bool isOn = false;

    override public void CustomScript (Trigger trigger)
    {
        isOn = !isOn;

        if (isOn)
        {
            at.SfxBoard(1);
            triggerIcon = TriggerIcon.CandleOff;
        }
        else
        {
            at.SfxBoard(2);
            triggerIcon = TriggerIcon.CandleOn;
        }

        RefreshIcon();
        roomScript.ToggleCandles(isOn);
    }

}
