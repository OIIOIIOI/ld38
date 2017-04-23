using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{

    public BoxCollider2D[] triggers;

    public Texture2D cursor;

	void Start ()
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
	}
	
	void Update ()
    {
		
	}

}
