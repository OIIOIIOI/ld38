using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveCompass : MonoBehaviour
{

    public int compass;

    protected Global global;

    private void Awake()
    {
        global = GameObject.Find("GLOBAL").GetComponent<Global>();
    }

    void Start ()
    {
        float rotation = 0;
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

}
