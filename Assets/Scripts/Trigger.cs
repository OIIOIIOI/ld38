using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour
{

    public string hoverText;

    public TargetScene targetScene;

    public enum TargetScene
    {
        Lobby, LobbyExitDoor,
        Bathroom,
        Stairs, StairsCompass,
        CompassRoom,
        Chapel, ChapelCircle,
        WhiteRoom,
        Library, LibraryCompass,
        BlueRoom, BlueRoomCompass,
        ColumnsRoom, ColumnsRoomDetail
    }

    Text cursorText;

	void Start ()
    {
        GameObject go = GameObject.Find("CursorText");
        if (go)
        {
            cursorText = go.GetComponent<Text>();
            cursorText.text = "";
        }
	}

    private void OnMouseEnter ()
    {
        if (cursorText)
            cursorText.text = hoverText;
    }

    private void OnMouseOver ()
    {
        if (cursorText)
            cursorText.gameObject.transform.position = Input.mousePosition;
    }

    private void OnMouseExit ()
    {
        if (cursorText)
            cursorText.text = "";
    }

    private void OnMouseDown ()
    {
        if (cursorText)
            cursorText.text = "";
        SceneManager.LoadScene(targetScene.ToString());
    }

}
