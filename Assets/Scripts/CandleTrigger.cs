using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleTrigger : Trigger
{
    
    public WhiteRoom room;

    new void Start()
    {
        base.Start();

        ResetIcon();
    }

    public override void CustomScript(Trigger trigger)
    {
        base.CustomScript(trigger);

        if (customParam == "first")
        {
            if (global.firstCandleOn) at.SfxBoard(2);
            else at.SfxBoard(1);

            global.firstCandleOn = !global.firstCandleOn;

            room.ToggleCandle(customParam);
        }
        else if (customParam == "third")
        {
            if (global.thirdCandleOn) at.SfxBoard(2);
            else at.SfxBoard(1);

            global.thirdCandleOn = !global.thirdCandleOn;

            room.ToggleCandle(customParam);
        }
        else
        {
            room.ResetRoom();
        }
        ResetIcon();
    }

    public void ResetIcon ()
    {
        if (customParam == "first")
        {
            if (global.firstCandleOn) triggerIcon = TriggerIcon.CandleOff;
            else triggerIcon = TriggerIcon.CandleOn;
        }
        if (customParam == "third")
        {
            if (global.thirdCandleOn) triggerIcon = TriggerIcon.CandleOff;
            else triggerIcon = TriggerIcon.CandleOn;
        }
        RefreshIcon();
    }

}
