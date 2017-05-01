using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{

    public int roomMusicIndex;

    AudioTracker at;
    Global global;

    public SpriteRenderer background;
    public GameObject trigger;

    private void Awake()
    {
        at = GameObject.Find("AudioTracker").GetComponent<AudioTracker>();
        global = GameObject.Find("GLOBAL").GetComponent<Global>();
    }

    private void Start()
    {
        trigger.SetActive(false);

        global.ResetAll();

        StartCoroutine(ShowScreen());
    }

    IEnumerator ShowScreen ()
    {
        yield return new WaitForSeconds(1f);

        for (float f = 0f; f <= 1f; f += 0.01f)
        {
            background.color = new Color(1f, 1f, 1f, f);
            yield return new WaitForFixedUpdate();
        }

        trigger.SetActive(true);

        yield return null;
    }

}
