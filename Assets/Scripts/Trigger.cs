using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour
{

    public string hoverText;
    public TargetType targetType;
    public TargetScene targetScene;
    public string[] dialogueTexts;

    public enum TargetType
    {
        Scene,
        Custom,
        Dialogue
    }

    public enum TargetScene
    {
        Lobby, LobbyExitDoor,
        Bathroom,
        Stairs, StairsCompass,
        CompassRoom,
        Chapel, ChapelDetail,
        WhiteRoom,
        Library, LibraryCompass,
        BlueRoom, BlueRoomCompass,
        ColumnsRoom, ColumnsRoomDetail
    }

    Text cursorTextUI;
    Text dialogueTextUI;

    protected void Start ()
    {
        GameObject go = GameObject.Find("CursorText");
        if (go)
        {
            cursorTextUI = go.GetComponent<Text>();
            cursorTextUI.text = "";
        }
        go = GameObject.Find("DialogueText");
        if (go)
        {
            dialogueTextUI = go.GetComponent<Text>();
            dialogueTextUI.text = "";
        }
    }

    void OnMouseEnter ()
    {
        if (cursorTextUI)
            cursorTextUI.text = hoverText;
    }

    void OnMouseOver ()
    {
        if (cursorTextUI)
            cursorTextUI.gameObject.transform.position = Input.mousePosition;
    }

    void OnMouseExit ()
    {
        if (cursorTextUI)
            cursorTextUI.text = "";
    }

    void OnMouseDown ()
    {
        switch (targetType)
        {
            case TargetType.Scene:
                if (cursorTextUI)
                    cursorTextUI.text = "";
                if (dialogueTextUI)
                    dialogueTextUI.text = "";
                SceneManager.LoadScene(targetScene.ToString());
                break;

            case TargetType.Dialogue:
                if (dialogueTextUI)
                {
                    string dt = "";
                    if (dialogueTexts.Length > 0)
                        dt = dialogueTexts[Random.Range(0, dialogueTexts.Length)];
                    dialogueTextUI.text = dt;
                }
                break;

            case TargetType.Custom:
                CustomScript();
                break;
        }
    }

    protected virtual void CustomScript () { }

}
