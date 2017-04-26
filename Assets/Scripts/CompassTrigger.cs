using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassTrigger : Trigger
{
    
    public int compass;
    public int correctRotation;

    bool rotating = false;
    int rotation;
    
    new void Start ()
    {
        base.Start();

        rotation = 0;
        switch (compass)
        {
            case 1:
                rotation = global.compassRotationA;
                break;
            case 2:
                rotation = global.compassRotationB;
                break;
            case 3:
                rotation = global.compassRotationC;
                break;
        }
        transform.Rotate(Vector3.forward, -90f * rotation);
    }

    override protected void CustomScript (Trigger trigger)
    {
        if (!rotating)
        {
            rotation += 1;
            if (rotation >= 4)
                rotation = 0;

            switch (compass)
            {
                case 1:
                    global.compassRotationA = rotation;
                    break;
                case 2:
                    global.compassRotationB = rotation;
                    break;
                case 3:
                    global.compassRotationC = rotation;
                    break;
            }

            if (rotation == correctRotation)
                Debug.Log("CORRECT");

            if (rotation == correctRotation)
                global.ValidateClue("compass" + compass);
            else
                global.InvalidateClue("compass" + compass);

            rotating = true;
            at.SfxBoard(5);
            StartCoroutine("RotateWheel");
        }
    }

    IEnumerator RotateWheel ()
    {
        for (float f = 0f; f <= 1f; f += 0.1f)
        {
            transform.Rotate(Vector3.forward, -9f);
            yield return new WaitForFixedUpdate();
        }
        rotating = false;
        yield return null;
    }

}
