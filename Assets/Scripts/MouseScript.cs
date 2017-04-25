﻿using UnityEngine;
using System.Collections;


public class MouseScript : MonoBehaviour {

	string[] CursorList = { "01", "02", "03", "04", "05", "06", "07", "08", "09","10"}; // REM
	int pointerint = 0; // REM
	int previouspointer= 0; //REM
	bool fadeactiv = false ;

		 
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
	float attenuator2000 = 1.0f;


	public Texture2D Background;

	Texture2D currentcursor ;
			

		void Start	()
	{
		currentcursor = Cursor9;
		Cursor.visible = false;
					
	}

	void Update(){






		if (pointerint != previouspointer) MouseCursor (pointerint); // REM
	}

	public void MouseCursor(int pointer) {



		if (fadeactiv == false)  StartCoroutine (CandleIzer (Random.Range (0.6f, 0.8f), Random.Range (0.8f, 1.0f), 2f));
	
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
		 previouspointer = pointerint; // REM
	}

	IEnumerator CandleIzer(float min,float max, float aTime) {


		fadeactiv = true;
		float step = 0.01f;
		for (float t = 0.0f; t < 1.0f; t += step) {
			attenuator2000 = Mathf.Lerp (max, min, t);
			yield return new WaitForSeconds(aTime*step);
		}
			for (float t = 0.0f; t < 1.0f; t += step)
		{	attenuator2000 = Mathf.Lerp(min,max,t);


			yield return new WaitForSeconds(aTime*step);

		}
		fadeactiv = false;
	}


	void OnGUI (){ // REM
		
		//GUI.DrawTexture (new Rect (0f, 0f, Screen.width, Screen.height), Background);
		//GUILayout.Box ("Pointers");
		//pointerint = GUILayout.SelectionGrid (pointerint,  CursorList ,4);
		GUI.color = Color.HSVToRGB (0.65f, attenuator2000-0.17f,1 );
		GUI.DrawTexture (new Rect ((Input.mousePosition.x-16), (Screen.height - Input.mousePosition.y-16), currentcursor.width/2, currentcursor.height/2), currentcursor);
	}	
}
