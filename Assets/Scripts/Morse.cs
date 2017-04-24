using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morse : MonoBehaviour
{

    public Background background;
    public string pattern;

    float fadeStep = 0.3f;
    float tick = 0.6f;

    private void Start()
    {
        float delay = 0f;
        string[] pat = pattern.Split(',');
        foreach (string s in pat)
        {
            switch (s)
            {
                case "S":
                    delay += tick + tick;
                    break;

                case "L":
                    delay += tick * 3f + tick;
                    break;
            }
        }
        delay += tick * 7f;

        InvokeRepeating("StartMorse", 1f, delay);
    }

    void StartMorse()
    {
        float delay = 0f;
        string[] pat = pattern.Split(',');
        foreach (string s in pat)
        {
            switch (s)
            {
                case "S":
                    Invoke("BlinkShort", delay);
                    delay += tick + tick;
                    break;

                case "L":
                    Invoke("BlinkLong", delay);
                    delay += tick * 3f + tick;
                    break;
            }
        }
    }

    void BlinkShort()
    {
        background.Flash(0, fadeStep, fadeStep, tick);
    }

    void BlinkLong()
    {
        background.Flash(0, fadeStep, fadeStep, tick * 3);
    }

}
