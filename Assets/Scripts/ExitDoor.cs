using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{

    public int roomMusicIndex;

    AudioTracker at;
    Global global;

    public Collider2D[] triggersToHide;
    public GameObject[] objectsToHide;
    public SpriteRenderer background;

    public PostProcessingBehaviour ppb;

    private void Awake()
    {
        at = GameObject.Find("AudioTracker").GetComponent<AudioTracker>();
        global = GameObject.Find("GLOBAL").GetComponent<Global>();
    }

    private void Start()
    {
        at.RoomBoard(roomMusicIndex);
    }

    public void CheckLock ()
    {
        if (global.lockNumberA == 4 &&
            global.lockNumberB == 8 &&
            global.lockNumberC == 2)
        {
            at.SfxBoard(9);

            foreach (Collider2D coll in triggersToHide)
                coll.enabled = false;

            StartCoroutine(OpenDoor());
        }
    }

    IEnumerator OpenDoor ()
    {
        yield return new WaitForSeconds(1f);

        PostProcessingProfile ppp = ppb.profile;

        var bloom = ppp.bloom.settings;
        float i = 0f;
        while (i < 150f)
        {
            i += (i + 1f) * 0.03f;
            bloom.bloom.intensity = i;
            ppp.bloom.settings = bloom;
            yield return new WaitForFixedUpdate();
        }

        foreach (GameObject go in objectsToHide)
            go.SetActive(false);

        for (float f = 1f; f >= 0f; f -= 0.01f)
        {
            background.color = new Color(1f, 1f, 1f, f);
            yield return new WaitForFixedUpdate();
        }

        SceneManager.LoadScene("EndScreen");

        yield return null;
    }

}
