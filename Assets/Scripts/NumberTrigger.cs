using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NumberTrigger : Trigger
{

    public int slot;
    public GameObject[] prefabs;
    public ExitDoor doorScript;

    GameObject current;
    int currentNumber;

    new void Start ()
    {
        base.Start();

        currentNumber = 1;
        switch (slot)
        {
            case 0:
                currentNumber = global.lockNumberA;
                break;
            case 1:
                currentNumber = global.lockNumberB;
                break;
            case 2:
                currentNumber = global.lockNumberC;
                break;
        }
        SetNumber(currentNumber);
    }

    void SetNumber (int n)
    {
        if (current != null)
            Destroy(current.gameObject);

        current = Instantiate(prefabs[n - 1], transform);
    }

    override public void CustomScript (Trigger trigger)
    {
        at.SfxBoard(5);

        currentNumber += 1;
        if (currentNumber > 9)
            currentNumber = 1;

        switch (slot)
        {
            case 0:
                global.lockNumberA = currentNumber;
                break;
            case 1:
                global.lockNumberB = currentNumber;
                break;
            case 2:
                global.lockNumberC = currentNumber;
                break;
        }
        SetNumber(currentNumber);
        doorScript.CheckLock();
    }

}
