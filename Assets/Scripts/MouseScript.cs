﻿using UnityEngine;
using System.Collections;


public class MouseScript : MonoBehaviour
{
    
    public Texture2D Cursor1;
    public Texture2D Cursor2;
    public Texture2D Cursor3;
    public Texture2D Cursor4;
    public Texture2D Cursor5;
    public Texture2D Cursor6;
    public Texture2D Cursor7;
    public Texture2D Cursor8;
    public Texture2D Cursor9;
    public Texture2D Cursor10;
    
    float previousx = 0f;
    float previousy = 0f;
    Color Mousecolor = new Color(1f, 1f, 1f, 0.25f);
    Color stay = new Color(1f, 1f, 1f, 0.25f);
    Color move = new Color(1f, 1f, 1f, 0.95f);
    bool fadein = false;
    //bool fadeactiv = false;

    Texture2D currentcursor;

    void Start ()
    {
        currentcursor = Cursor10;
        Cursor.visible = false;
    }

    void Update ()
    {
        if (Input.mousePosition.x != previousx || Input.mousePosition.y != previousy)
        {
            if (fadein == false)
            {
                StopAllCoroutines();
                StartCoroutine(StaytoMove(0.3f));
            }
        }
        else
        {
            if (fadein == true) StopAllCoroutines();
            StartCoroutine(MovetoStay(100f));
        }
    }

    public void MouseCursor (int pointer)
    {
        if (pointer == 0) currentcursor = Cursor1;
        if (pointer == 1) currentcursor = Cursor2;
        if (pointer == 2) currentcursor = Cursor3;
        if (pointer == 3) currentcursor = Cursor4;
        if (pointer == 4) currentcursor = Cursor5;
        if (pointer == 5) currentcursor = Cursor6;
        if (pointer == 6) currentcursor = Cursor7;
        if (pointer == 7) currentcursor = Cursor8;
        if (pointer == 8) currentcursor = Cursor9;
        if (pointer == 9) currentcursor = Cursor10;
    }
    
    IEnumerator StaytoMove (float aTime)
    {
        fadein = true;
        float step = 0.01f;
        for (float t = 0.0f; t < 1.0f; t += step)
        {
            Mousecolor = Color.Lerp(Mousecolor, move, t);
            yield return new WaitForSeconds(aTime * step);
        }
    }
    
    IEnumerator MovetoStay(float aTime)
    {
        fadein = false;
        float step = 0.01f;
        for (float t = 0.0f; t < 1.0f; t += step)
        {
            Mousecolor = Color.Lerp(Mousecolor, stay, t);
            yield return new WaitForSeconds(aTime * step);
        }
    }

    void OnGUI()
    {
        GUI.color = Mousecolor;
        previousx = Input.mousePosition.x;
        previousy = Input.mousePosition.y;
        GUI.DrawTexture(new Rect((Input.mousePosition.x - 16), (Screen.height - Input.mousePosition.y - 16), currentcursor.width / 2, currentcursor.height / 2), currentcursor);
    }

}
