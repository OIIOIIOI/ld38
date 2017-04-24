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
        Rotate,
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
    Text dialogueTextUI;
    Vector2 cursorPosition = new Vector2(32, 32);

    private void Awake()
    {
        dialogueTextUI = GameObject.Find("DialogueText").GetComponent<Text>();
        global = GameObject.Find("GLOBAL").GetComponent<Global>();
    }

    protected void Start ()
    {
        dialogueTextUI.text = "";
    }

    void OnMouseEnter ()
    {
        Texture2D icon = null;
        switch (triggerIcon)
        {
            case TriggerIcon.LookAt:
                icon = global.LookAtIcon;
                break;
            case TriggerIcon.CandleOff:
                icon = global.CandleOffIcon;
                break;
            case TriggerIcon.CandleOn:
                icon = global.CandleOnIcon;
                break;
            case TriggerIcon.GoBackwardDown:
                icon = global.GoBackwardDownIcon;
                break;
            case TriggerIcon.GoForwardUp:
                icon = global.GoForwardUpIcon;
                break;
            case TriggerIcon.GoLeft:
                icon = global.GoLeftIcon;
                break;
            case TriggerIcon.GoRight:
                icon = global.GoRightIcon;
                break;
            case TriggerIcon.Rotate:
                icon = global.RotateIcon;
                break;
            case TriggerIcon.Use:
                icon = global.UseIcon;
                break;
        }
        Cursor.SetCursor(icon, cursorPosition, CursorMode.Auto);
    }

    void OnMouseExit ()
    {
        Cursor.SetCursor(null, cursorPosition, CursorMode.Auto);
    }

    void OnMouseDown ()
    {
        switch (targetType)
        {
            case TargetType.Scene:
                //if (cursorTextUI)
                    //cursorTextUI.text = "";
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
