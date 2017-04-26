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
    public string customParam;

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
        Use,
        Default
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

    protected Global global;
    protected AudioTracker at;
    protected MouseScript mouseScript;
    protected Text dialogueTextUI;
    protected Vector2 cursorPosition = new Vector2(32, 32);

    private void Awake()
    {
        at = GameObject.Find("AudioTracker").GetComponent<AudioTracker>();
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
        RefreshIcon();
    }

    protected void RefreshIcon ()
    {
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
            default:
                mouseScript.MouseCursor(9);
                break;
        }
    }

    void OnMouseExit ()
    {
        mouseScript.MouseCursor(9);
    }

    void OnMouseDown ()
    {
        switch (targetType)
        {
            case TargetType.Scene:
                if (dialogueTextUI)
                    dialogueTextUI.text = "";
                mouseScript.MouseCursor(9);
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
                CustomScript(this);
                break;
        }
    }

    protected virtual void CustomScript (Trigger trigger) { }

}
