using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoHideText : MonoBehaviour
{

    Text textField;

    public void Awake ()
    {
        textField = GetComponent<Text>();
    }

    public void SetText (string text)
    {
        CancelInvoke();

        textField.text = text;
        Invoke("HideText", 2f);
    }

    void HideText ()
    {
        textField.text = "";
    }

}
