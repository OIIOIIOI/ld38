using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bathroom : MonoBehaviour
{

    public Background background;

    private void Start ()
    {
        InvokeRepeating("Lightning", 3f, 3f);
    }

    void Lightning ()
    {
        background.Swap();
    }

}
