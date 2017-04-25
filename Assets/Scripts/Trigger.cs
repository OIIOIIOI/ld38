using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour
{
    
    public TriggerIcon triggerIcon;
    public TargetType targetType;
    public TargetScene targetScene;
    public string[] dialogueTexts;

    public enum TriggerIcon
    {
        LookAt,
        CandleOn,
        CandleOff,
        GoForwardUp,
        GoRight,
        GoBackwardDown,
        GoLeft,
        Rotator,
        Use
    }

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

    Global global;
    MouseScript mouseScript;
    Text dialogueTextUI;
    Vector2 cursorPosition = new Vector2(32, 32);

    private void Awake()
    {
        dialogueTextUI = GameObject.Find("DialogueText").GetComponent<Text>();
        global = GameObject.Find("GLOBAL").GetComponent<Global>();
        mouseScript = GameObject.Find("GLOBAL").GetComponent<MouseScript>();
    }

    protected void Start ()
    {
        //dialogueTextUI.text = "";
    }

    void OnMouseEnter ()
    {
        //Debug.Log(triggerIcon);
        //Texture2D icon = null;
        switch (triggerIcon)
        {
            case TriggerIcon.LookAt:
                mouseScript.MouseCursor(7);
                break;
            case TriggerIcon.CandleOff:
                mouseScript.MouseCursor(1);
                break;
            case TriggerIcon.CandleOn:
                mouseScript.MouseCursor(0);
                break;
            case TriggerIcon.GoBackwardDown:
                mouseScript.MouseCursor(4);
                break;
            case TriggerIcon.GoForwardUp:
                mouseScript.MouseCursor(2);
                break;
            case TriggerIcon.GoLeft:
                mouseScript.MouseCursor(5);
                break;
            case TriggerIcon.GoRight:
                mouseScript.MouseCursor(3);
                break;
            case TriggerIcon.Use:
                mouseScript.MouseCursor(8);
                break;
            case TriggerIcon.Rotator:
                mouseScript.MouseCursor(6);
                break;
        }
        //Cursor.SetCursor(icon, cursorPosition, CursorMode.Auto);
    }

    void OnMouseExit ()
    {
        mouseScript.MouseCursor(9);
        //return;
        //Cursor.SetCursor(null, cursorPosition, CursorMode.Auto);
    }

    void OnMouseDown ()
    {
        switch (targetType)
        {
            case TargetType.Scene:
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
