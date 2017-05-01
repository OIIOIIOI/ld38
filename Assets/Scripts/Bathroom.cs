using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bathroom : MonoBehaviour
{

    public int roomMusicIndex;
    public Background background;
    public SpriteRenderer number;

    AudioTracker at;
    Global global;

    private void Awake ()
    {
        at = GameObject.Find("AudioTracker").GetComponent<AudioTracker>();
        global = GameObject.Find("GLOBAL").GetComponent<Global>();
    }

    private void Start ()
    {
        at.RoomBoard(roomMusicIndex);
        number.gameObject.SetActive(false);

        //Invoke("Lightning", Random.Range(8f, 20f));
        Invoke("Lightning", 2f);
    }

    void Lightning ()
    {
        background.Flash(0, 0.3f, 0.15f, 0.2f);
        StartCoroutine(BlinkSprite(0.3f, 0.15f, 0.2f));

        global.ValidateClue("bathroom");

        Invoke("LightningSFX", Random.Range(0.2f, 0.6f));
        Invoke("Lightning", Random.Range(8f, 20f));
    }

    void LightningSFX ()
    {
        at.SfxBoard(10);
    }

    IEnumerator BlinkSprite(float fadeInStep, float fadeOutStep, float flashTime)
    {
        number.gameObject.SetActive(true);
        number.color = Color.clear;

        for (float f = 0f; f <= 1f; f += fadeInStep)
        {
            number.color = new Color(1f, 1f, 1f, f);
            yield return new WaitForFixedUpdate();
        }
        number.color = new Color(1, 1, 1, 1);

        if (flashTime > 0f)
            yield return new WaitForSeconds(flashTime);

        for (float f = 1f; f >= 0f; f -= fadeOutStep)
        {
            number.color = new Color(1f, 1f, 1f, f);
            yield return new WaitForFixedUpdate();
        }

        number.color = Color.clear;
        number.gameObject.SetActive(false);
        yield return null;
    }

}
